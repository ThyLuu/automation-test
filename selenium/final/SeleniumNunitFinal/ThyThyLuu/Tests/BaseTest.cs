using NUnit.Framework;
using OpenQA.Selenium;

namespace FinalSelenium
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected DriverUtils driverUtils = null!;

        [SetUp]
        public void Setup()
        {
            string browser = ConfigurationUtils.GetString("Browser");
            string url = ConfigurationUtils.GetString("TestUrl");

            DriverFactory.InitializeDriver(browser);

            driver = DriverFactory.GetWebDriver();

            driverUtils = new DriverUtils(driver);

            ExtentReportHelper.CreateTest(TestContext.CurrentContext.Test.Name);

            driverUtils.GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            DriverFactory.CleanUpWebDriver();

            var status = TestContext.CurrentContext.Result.Outcome.Status;

            var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : TestContext.CurrentContext.Result.StackTrace;

            ExtentReportHelper.CreateTestResult(
                status,
                stackTrace,
                TestContext.CurrentContext.Test.ClassName,
                TestContext.CurrentContext.Test.Name
            );

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}