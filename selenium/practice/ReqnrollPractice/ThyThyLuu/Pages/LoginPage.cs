using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ThyThyLuu.Pages;

public class LoginPage : BasePage
{
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    private By usernameInput = By.Id("username");
    private By passwordInput = By.Id("password");
    private By submitBtn = By.CssSelector("input[type='submit']");
    private By errorMessage = By.XPath("//div[@role='alert' and contains(text(), 'The Username or Password you entered is incorrect')]");
    private By requiredMessage = By.XPath("//p[contains(normalize-space(), 'This is a required field.')]");

    // expected url when login successfully
    private string searchPageUrl = "http://192.168.237.15:3000/#!/search";

    public void EnterUsername(string usernameValue)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        IWebElement usernameElement = wait.Until(
            d => d.FindElement(usernameInput)
        );

        usernameElement.Clear();
        usernameElement.SendKeys(usernameValue);
    }

    public void EnterPassword(string passwordValue)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        IWebElement passwordElement = wait.Until(
            d => d.FindElement(passwordInput)
        );

        passwordElement.Clear();
        passwordElement.SendKeys(passwordValue);
    }

    public void ClickSubmit()
    {
        driver.FindElement(submitBtn).Click();
    }

    public void Login(string username, string password)
    {
        EnterUsername(username);
        EnterPassword(password);
        ClickSubmit();
    }

    public bool IsLoginSuccess()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        return wait.Until(
            d => d.Url.Equals(searchPageUrl)
        );
    }

    public string GetErrorMessage()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        IWebElement errorMessageElement = wait.Until(
            d => d.FindElement(errorMessage)
        );

        return errorMessageElement.Text.Trim();
    }

    public string GetRequiredFieldDisplays()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        IWebElement requiredMessageElement = wait.Until(
            d => d.FindElement(requiredMessage)
        );

        return requiredMessageElement.Text.Trim();
    }
}