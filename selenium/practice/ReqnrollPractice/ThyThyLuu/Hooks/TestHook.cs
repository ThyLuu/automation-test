using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

[Binding]
public class TestHook
{
    public static IWebDriver driver;

    [BeforeScenario]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [AfterScenario]
    public void TearDown()
    {
        driver.Quit();
    }
}