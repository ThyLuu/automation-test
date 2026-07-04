using System.Security.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalSelenium
{
    public class ProfileTest : BaseTest
    {
        private LoginModel login;
        private BookModel book;
        private HomePage homePage;
        private BooksPage booksPage;
        private LoginPage loginPage;
        private ProfilePage profilePage;

        [SetUp]
        public void Init()
        {
            login = JsonUtils.ReadJson<LoginModel>("LoginData.json");
            book = JsonUtils.ReadJson<BookModel>("DeleteBooksData.json");

            homePage = new HomePage(driver);
            booksPage = new BooksPage(driver);
            loginPage = new LoginPage(driver);
            profilePage = new ProfilePage(driver);

            homePage.ClickBooks();
            booksPage.ClickLoginBtn();
            loginPage.Login(login.UserName, login.Password);
            profilePage.ClickGoToBookStore();
            booksPage.SearchBook(book.BookTitle);
            booksPage.ClickBookTitle();
            booksPage.ClickAddToYourCollection();
            booksPage.AcceptAlert();
            booksPage.NavigateToProfilePage();
        }

        [Test]
        public void DeleteBook()
        {
            profilePage.ClickDeleteBtn();
            profilePage.ClickOkBtn();
            profilePage.AcceptAlert();
            
            List<string> books = profilePage.GetBookTitle();
            Assert.That(books, Does.Not.Contain(book.BookTitle));
        }
    }
}

