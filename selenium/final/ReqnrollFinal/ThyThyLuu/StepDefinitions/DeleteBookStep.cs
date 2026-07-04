using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using Reqnroll;

[Binding]
public class DeleteBookStep
{
    private readonly HomePage _homePage;
    private readonly LoginPage _loginPage;
    private readonly ProfilePage _profilePage;
    private readonly BooksPage _bookPage;

    private readonly AccountService _accountService;
    private readonly BookStoreService _bookStoreService;

    private string _token = string.Empty;
    private string _bookName = string.Empty;

    public DeleteBookStep(TestContext context)
    {
        _loginPage = new LoginPage(context.Driver!);
        _profilePage = new ProfilePage(context.Driver!);
        _homePage = new HomePage(context.Driver!);
        _bookPage = new BooksPage(context.Driver!);

        _accountService = new AccountService();
        _bookStoreService = new BookStoreService();
    }

    [Given(@"there is a book named ""(.*)"" with isbn ""(.*)"" for user ""(.*)"" using ""(.*)"" and ""(.*)""")]
    public async Task GivenThereIsABookNamedWithIsbn(string bookName, string isbn, string userId, string username, string password)
    {
        _bookName = bookName;

        var response = await _accountService.GenerateToken(
            username,
            password
        );

        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Content!);

        _token = tokenResponse!.Token!;

        var requestBody = new AddBookRequest
        {
            UserId = userId,
            CollectionOfIsbns =
            [
                new IsbnItem
                {
                    Isbn = isbn
                }
            ]
        };

        var addBookResponse =await _bookStoreService.AddBook(
            _token,
            requestBody
        );

        addBookResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        addBookResponse.IsSuccessful.Should().BeTrue();
    }

    [Given(@"the user logs into the application with ""(.*)"" and ""(.*)""")]
    public void GivenTheUserLogsIntoTheApplicationWithCredentials(string username, string password)
    {
        _homePage.NavigateToBooksPage();
        _bookPage.ClickLoginBtn();

        _loginPage.Login(
            username,
            password);

        _loginPage.WaitForProfilePage();
    }

    [Given(@"the user is on the Profile page")]
    public void GivenTheUserIsOnTheProfilePage()
    {
        _profilePage
            .GetLoggedInUsername()
            .Should()
            .NotBeNullOrEmpty();
    }

    [When(@"the user search book ""(.*)""")]
    public void WhenTheUserSearchBook(string bookName)
    {
        _profilePage.SearchBook(bookName);
    }

    [When(@"the user clicks on Delete icon")]
    public void WhenTheUserClicksOnDeleteIcon()
    {
        _profilePage.ClickDeleteBtn();
    }

    [When(@"the user clicks on OK button")]
    public void WhenTheUserClicksOnOKButton()
    {
        _profilePage.ClickOkBtn();
    }

    [When(@"the user clicks on OK button of alert ""(.*)""")]
    public void WhenTheUserClicksOnOKButtonOfAlert(string expectedMessage)
    {
        _profilePage.AcceptAlert();
    }

    [Then(@"the book is not shown")]
    public void ThenTheBookIsNotShown()
    {
        _profilePage
            .GetBookTitle()
            .Should()
            .NotContain(_bookName);
    }
}

