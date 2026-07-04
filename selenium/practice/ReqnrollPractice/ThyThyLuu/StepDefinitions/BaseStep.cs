using OpenQA.Selenium;
using Reqnroll;
using ThyThyLuu.Pages;

namespace ThyThyLuu.StepDefinitions;

[Binding]
public class BaseStep
{
    private readonly IWebDriver driver;
    private readonly LoginPage loginPage;

    public BaseStep()
    {
        driver = TestHook.driver;
        loginPage = new LoginPage(driver);
    }

    [Given("the user logged into the application")]
    public void GivenTheUserLoggedIntoTheApplication()
    {
        driver.Navigate().GoToUrl(Config.BaseUrl);

        loginPage.Login("Admin2", "Fxu1tw^E");

        Assert.That(
            loginPage.IsLoginSuccess(),
            Is.True
        );
    }
}