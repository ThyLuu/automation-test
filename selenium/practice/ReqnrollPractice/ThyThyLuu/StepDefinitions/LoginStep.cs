using OpenQA.Selenium;
using Reqnroll;
using ThyThyLuu.Pages;
using ThyThyLuu.Models;

namespace ThyThyLuu.StepDefinitions;

[Binding]
public class LoginSteps
{
    private readonly IWebDriver driver;
    private readonly LoginPage loginPage;

    private Account account = new();

    public LoginSteps()
    {
        driver = TestHook.driver;
        loginPage = new LoginPage(driver);
    }

    [Given("the user visits the TMS website")]
    public void GivenTheUserVisitsTheTMSWebsite()
    {
        driver.Navigate().GoToUrl("http://192.168.237.15:3000");
    }

    [When(@"the user enters username ""(.*)"" and password ""(.*)""")]
    public void WhenTheUserEntersUsernameAndPassword(string username, string password)
    {
        account.Username = username;
        account.Password = password;

        loginPage.EnterUsername(username);
        loginPage.EnterPassword(password);
    }

    [When("the user clicks on Login button")]
    public void WhenTheUserClicksOnLoginButton()
    {
        loginPage.ClickSubmit();
    }

    [Then("the user is logged into the system successfully")]
    public void ThenTheUserIsLoggedIntoTheSystemSuccessfully()
    {
        Assert.That(
            loginPage.IsLoginSuccess(),
            Is.True
        );
    }

    [Then("the error message will be displayed")]
    public void ThenTheErrorMessageWillBeDisplayed()
    {
        string expectedErrorMessage = "The Username or Password you entered is incorrect";
        string expectedRequiredMessage = "This is a required field.";

        if (string.IsNullOrEmpty(account.Username) ||
            string.IsNullOrEmpty(account.Password))
        {
            Assert.That(
                loginPage.GetRequiredFieldDisplays(),
                Is.EqualTo(expectedRequiredMessage)
            );
        }
        else
        {
            Assert.That(
                loginPage.GetErrorMessage(),
                Is.EqualTo(expectedErrorMessage)
            );
        }
    }
}