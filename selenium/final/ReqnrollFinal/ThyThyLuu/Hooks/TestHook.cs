using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;

[Binding]
public class TestHook
{
    private TestContext _context;
    private IObjectContainer _container;

    public TestHook(TestContext context, IObjectContainer container)
    {
        this._context = context;
        this._container = container;
    }

    [BeforeScenario]
    public void Setup()
    {
        var options = new ChromeOptions();

        options.AddExcludedArgument("enable-automation");
        options.AddAdditionalOption("useAutomationExtension", false);

        _context.Driver = new ChromeDriver(options);

        _container.RegisterInstanceAs<IWebDriver>(_context.Driver);

        _context.Driver.Manage().Window.Maximize();
        _context.Driver.Navigate().GoToUrl("https://demoqa.com");
    }

    [AfterScenario]
    public void TearDown()
    {
        _context.Driver?.Quit();
    }
}