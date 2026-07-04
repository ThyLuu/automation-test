using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Globalization;

public static class WebObjectExtensions
{

    private static WebDriverWait GetWait(WebObject webObject)
    {
        return new WebDriverWait(
            webObject.Driver,
            TimeSpan.FromSeconds(30)
        );
    }

    public static IWebElement GetElement(this WebObject webObject)
    {
        return GetWait(webObject).Until(
            ExpectedConditions.ElementIsVisible(webObject.By)
        );
    }

    public static void ClickOnElement(this WebObject webObject)
    {
        var wait = GetWait(webObject);

        IWebElement element = wait.Until(
            ExpectedConditions.ElementToBeClickable(webObject.By));

        element.Click();
    }

    public static void EnterText(this WebObject webObject, string text)
    {
        var wait = GetWait(webObject);

        var element = wait.Until(
            ExpectedConditions.ElementIsVisible(webObject.By));

        element.SendKeys(text);
    }

    public static bool IsDisplayed(this WebObject webObject)
    {
        return webObject.GetElement().Displayed;
    }

    public static void SelectDate(this WebObject webObject, string date)
    {
        var driver = webObject.Driver;

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        var parts = date.Split(' ');
        var day = int.Parse(parts[0]).ToString();
        var month = parts[1];
        var year = parts[2];

        var monthFull = DateTime.ParseExact(month, "MMM", CultureInfo.InvariantCulture)
                                .ToString("MMMM");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("dateOfBirthInput"))).Click();

        var yearSelect = new SelectElement(
            wait.Until(d => d.FindElement(By.ClassName("react-datepicker__year-select")))
        );
        yearSelect.SelectByText(year);

        var monthSelect = new SelectElement(
            wait.Until(d => d.FindElement(By.ClassName("react-datepicker__month-select")))
        );
        monthSelect.SelectByText(monthFull);

        var dayLocator = By.XPath(
            $"//div[contains(@class,'react-datepicker__day') and not(contains(@class,'--outside-month')) and text()='{day}']"
        );

        wait.Until(ExpectedConditions.ElementToBeClickable(dayLocator)).Click();
    }

    public static void ScrollToCenter(this WebObject webObject)
    {
        // var driver = DriverFactory.GetWebDriver();
        var driver = webObject.Driver;
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        var element = wait.Until(d => d.FindElement(webObject.By));

        ((IJavaScriptExecutor)driver)
            .ExecuteScript(
                "arguments[0].scrollIntoView({block: 'center'});",
                element
            );
    }

    public static void ScrollToTop(this IWebDriver driver)
    {
        ((IJavaScriptExecutor)driver)
            .ExecuteScript("window.scrollTo(0, 0);");

        new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            .Until(d =>
                (long)((IJavaScriptExecutor)d)
                    .ExecuteScript("return window.pageYOffset;") == 0);
    }
}