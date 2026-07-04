using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class DriverFactory
{
    public static IWebDriver InitDriver()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");

        return new ChromeDriver(options);
    }
}