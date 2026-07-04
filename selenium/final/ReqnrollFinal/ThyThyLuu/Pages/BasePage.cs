using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
    }

    protected IWebElement WaitUntilVisible(By locator)
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    protected IAlert WaitForAlert()
    {
        return wait.Until(ExpectedConditions.AlertIsPresent());
    }

    protected void WaitUntilUrlContains(string text)
    {
        wait.Until(d => d.Url.Contains(text));
    }
    
}