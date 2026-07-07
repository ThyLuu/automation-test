
namespace FinalSelenium
{
    public class BooksTest : BaseTest
    {
        private BookModel book;
        private BooksPage booksPage;
        private HomePage homePage;

        [SetUp]
        public void Init()
        {
            book = JsonUtils.ReadJson<BookModel>("SearchBooksData.json");

            homePage = new HomePage(driver);
            booksPage = new BooksPage(driver);

            homePage.ClickBooks();
        }

        [Test]
        public void SearchBookWithMultipleResults()
        {
            booksPage.SearchBook(book.BookTitle);

            var titles = booksPage.GetAllBookTitles();
            Assert.Multiple(() =>
            {
                Assert.That(titles.Count, Is.GreaterThan(0));

                Assert.That(
                    titles.All(t =>
                        t.Contains(book.BookTitle, StringComparison.OrdinalIgnoreCase)
                    ),
                    Is.True
                );
            });
        }
    }
}

