
namespace FinalSelenium
{
    public class LoginTest : BaseTest
    {
        private LoginModel login;
        private HomePage homePage;
        private BooksPage booksPage;
        private LoginPage loginPage;

        [SetUp]
        public void Init()
        {
            login = JsonUtils.ReadJson<LoginModel>("LoginData.json");

            homePage = new HomePage(driver);
            booksPage = new BooksPage(driver);
            loginPage = new LoginPage(driver);

            homePage.ClickBooks();
            booksPage.ClickLoginBtn();
        }

        [Test]
        public void Login()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage.Login(login.UserName, login.Password);
            loginPage.WaitForProfilePage();

            Assert.That(driver.Url, Is.EqualTo(loginPage.expectedResult));
        }
    }
}

