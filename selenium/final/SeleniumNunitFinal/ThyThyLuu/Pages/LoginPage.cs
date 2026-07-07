using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPage : BasePage
{
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    private WebObject _userNameInput = new WebObject(By.Id("userName"), "Username input");
    private WebObject _passwordInput = new WebObject(By.Id("password"), "Password input");
    private WebObject _loginBtn = new WebObject(By.Id("login"), "Login button");
    public string expectedResult => "https://demoqa.com/profile";

    public void EnterUserName(string username)
    {
        _userNameInput.EnterText(username);

        ExtentReportHelper.LogInfo($"Login with username: {username}");
    }

    public void EnterPassword(string password)
    {
        _passwordInput.EnterText(password);

        ExtentReportHelper.LogInfo($"Login with password: {password}");
    }

    public void ClickLoginBtn()
    {
        _loginBtn.ClickOnElement();

        ExtentReportHelper.LogPass("Click Login button");
    }

    public void Login(string username, string password)
    {
        EnterUserName(username);
        EnterPassword(password);
        ClickLoginBtn();
    }

    public void WaitForProfilePage()
    {
        WaitUntilUrlContains("/profile");
    }

    // Verify
    public string GetLoggedInUsername()
    {
        return WaitUntilVisible(
            By.Id("userName-value")
        ).Text;
    }
}