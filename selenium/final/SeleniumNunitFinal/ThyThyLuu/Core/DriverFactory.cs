using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

public static class DriverFactory
{
    public static ThreadLocal<IWebDriver> ThreadLocalWebDriver = new ThreadLocal<IWebDriver>();

    public static void InitializeDriver(string browser)
    {
        switch (browser.ToLower())
        {
            case "chrome":
                ChromeOptions chromeOptions = new();

                chromeOptions.AddArgument("--start-maximized");

                ThreadLocalWebDriver.Value = new ChromeDriver(chromeOptions);

                break;

            case "edge":
                EdgeOptions edgeOptions = new();

                edgeOptions.AddArgument("--start-maximized");

                ThreadLocalWebDriver.Value = new EdgeDriver(edgeOptions);

                break;

            default:
                throw new ArgumentException(
                    "Browser is not supported"
                );
        }
    }

    public static IWebDriver GetWebDriver()
    {
        return ThreadLocalWebDriver.Value!;
    }

    public static void CleanUpWebDriver()
    {
        if (ThreadLocalWebDriver.Value != null)
        {
            ThreadLocalWebDriver.Value.Quit();
            ThreadLocalWebDriver.Value.Dispose();
        }
    }
}