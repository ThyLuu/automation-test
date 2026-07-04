using OpenQA.Selenium;
using Reqnroll;

[Binding]
public class SearchBookStep
{
    private readonly BooksPage _booksPage;
    private readonly HomePage _homePage;

    private string _keyword = string.Empty;

    public SearchBookStep(TestContext context)
    {
        _booksPage = new BooksPage(context.Driver!);
        _homePage = new HomePage(context.Driver!);
    }

    [Given(@"there are books available in the system")]
    public void GivenBooksAvailable()
    {
        _homePage.ClickBooks();

        Assert.That(
            _booksPage.GetAllBookTitles(),
            Is.Not.Empty,
            "Books list is not loaded"
        );
    }

    [Given(@"the user is on the Book Store page")]
    public void GivenTheUserIsOnBookStorePage()
    {
        _homePage.ClickBooks();
    }

    [When(@"the user searches for book ""(.*)""")]
    public void WhenTheUserSearchesForBook(string keyword)
    {
        _keyword = keyword;

        _booksPage.SearchBook(keyword);
    }

    [Then(@"all books returned should match the keyword ""(.*)""")]
    public void ThenAllBooksReturnedShouldMatchKeyword(string keyword)
    {
        var titles = _booksPage.GetAllBookTitles();

        Assert.Multiple(() =>
        {
            Assert.That(titles.Count, Is.GreaterThan(0));

            Assert.That(
                titles.All(t =>
                    t.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                ),
                Is.True
            );
        });
    }
}