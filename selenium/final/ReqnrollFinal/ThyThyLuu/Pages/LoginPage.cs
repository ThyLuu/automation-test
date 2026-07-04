using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPage : BasePage
{
    private readonly WebObject _userNameInput;
    private readonly WebObject _passwordInput;
    private readonly WebObject _loginBtn;

    public LoginPage(IWebDriver driver) : base(driver)
    {
        _userNameInput = new WebObject(driver, By.Id("userName"), "Username input");
        _passwordInput = new WebObject(driver, By.Id("password"), "Password input");
        _loginBtn = new WebObject(driver, By.Id("login"), "Login button");
    }
    
    public string expectedResult => "https://demoqa.com/profile";

    public void EnterUserName(string username)
    {
        _userNameInput.EnterText(username);
    }

    public void EnterPassword(string password)
    {
        _passwordInput.EnterText(password);
    }

    public void ClickLoginBtn()
    {
        _loginBtn.ClickOnElement();
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
        return WaitUntilVisible(By.Id("userName-value")).Text;
    }
}