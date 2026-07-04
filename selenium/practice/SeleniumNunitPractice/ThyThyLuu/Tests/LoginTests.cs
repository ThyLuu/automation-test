using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticeSelenium
{
    public class LoginTests : BaseTest
    {
        private LoginInformation loginInfomation = JsonHelper.ReadJson<LoginInformation>("UserData.json");
        private LoginPage loginPage;

        [SetUp]
        public void Init()
        {
            loginPage = new LoginPage(driver);
        }

        // Scenario 1: Login success
        [Test]
        public void LoginWithValidAccountSuccessfully()
        {
            loginPage.Login(loginInfomation.Username, loginInfomation.Password);

            Assert.That(
                loginPage.IsLoginSuccess(),
                Is.True
            );
        }

        // Scenario 2: Login unsuccess
        [Test]
        [TestCase("Admin2", "")]
        [TestCase("", "qp$#tGu^")]
        [TestCase("", "")]
        [TestCase("Admin1", "qp$#tGu3")]
        public void Login_With_Invalid_Account(string username, string password)
        {
            string expectedErrorMessage = "The Username or Password you entered is incorrect";
            string expectedRequiredMessage = "This is a required field.";

            loginPage.Login(username, password);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Assert.That(loginPage.GetRequiredFieldDisplays(), Is.EqualTo(expectedRequiredMessage));
            }
            else
            {
                Assert.That(loginPage.GetErrorMessage(), Is.EqualTo(expectedErrorMessage));
            }

        }
    }
}
