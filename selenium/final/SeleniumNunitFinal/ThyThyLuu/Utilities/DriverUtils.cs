using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class DriverUtils
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public DriverUtils(IWebDriver driver)
    {
        this.driver = driver;

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(
                ConfigurationUtils.GetInt("WaitTime")
            )
        );
    }

    public void GoToUrl(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    public string GetTitle()
    {
        return driver.Title;
    }
}