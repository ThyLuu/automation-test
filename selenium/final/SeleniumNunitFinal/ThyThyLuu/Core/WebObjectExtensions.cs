using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public static class WebObjectExtensions
{
    private static WebDriverWait GetWait()
    {
        return new WebDriverWait(
            DriverFactory.GetWebDriver(),
            TimeSpan.FromSeconds(30)
        );
    }

    public static IWebElement GetElement(this WebObject webObject)
    {
        return GetWait().Until(
            ExpectedConditions.ElementIsVisible(webObject.By)
        );
    }

    // public static void ClickOnElement(this WebObject webObject)
    // {
    //     var wait = GetWait();

    //     IWebElement element = wait.Until(
    //         ExpectedConditions.ElementToBeClickable(webObject.By));

    //     element.Click();
    // }

    public static void ClickOnElement(this WebObject webObject)
    {
        var driver = DriverFactory.GetWebDriver();
        var wait = GetWait();

        var element = wait.Until(
            ExpectedConditions.ElementToBeClickable(webObject.By));

        ((IJavaScriptExecutor)driver)
            .ExecuteScript(
                "arguments[0].scrollIntoView({block:'center'});",
                element);

        try
        {
            element.Click();
        }
        catch (ElementClickInterceptedException)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", element);
        }
    }

    public static void EnterText(this WebObject webObject, string text)
    {
        var wait = GetWait();

        wait.Until(ExpectedConditions.ElementIsVisible(webObject.By));

        var element = wait.Until(ExpectedConditions.ElementExists(webObject.By));

        element.SendKeys(text);
    }

    public static bool IsDisplayed(this WebObject webObject)
    {
        return webObject.GetElement().Displayed;
    }

    public static void SelectDate(this WebObject webObject, string date)
    {
        var driver = DriverFactory.GetWebDriver();

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        var parts = date.Split(' ');
        var day = int.Parse(parts[0]).ToString();
        var month = parts[1];
        var year = parts[2];

        wait.Until(ExpectedConditions.ElementToBeClickable(webObject.By)).Click();

        var yearSelect = new SelectElement(
            wait.Until(d => d.FindElement(By.ClassName("react-datepicker__year-select")))
        );
        yearSelect.SelectByText(year);

        var monthSelect = new SelectElement(
            wait.Until(d => d.FindElement(By.ClassName("react-datepicker__month-select")))
        );
        monthSelect.SelectByText(month);

        var dayLocator = By.XPath(
            $"//div[contains(@class,'react-datepicker__day') " +
            $"and not(contains(@class,'text-muted')) " +
            $"and text()='{day}']"
        );

        wait.Until(ExpectedConditions.ElementToBeClickable(dayLocator)).Click();
    }

    public static void ScrollToCenter(this WebObject webObject)
    {
        var driver = DriverFactory.GetWebDriver();
        var wait = GetWait();

        var element = wait.Until(d => d.FindElement(webObject.By));

        ((IJavaScriptExecutor)driver)
            .ExecuteScript(
                "arguments[0].scrollIntoView({block: 'center'});",
                element
            );
    }
}