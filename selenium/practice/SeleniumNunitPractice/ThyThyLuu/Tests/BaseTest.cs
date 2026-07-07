using NUnit.Framework;
using OpenQA.Selenium;

namespace PracticeSelenium
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.InitDriver();
            driver.Navigate().GoToUrl("http://192.168.237.15:3000");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                driver?.Quit();
            }
            finally
            {
                driver?.Dispose();
            }
        }
    }
}

