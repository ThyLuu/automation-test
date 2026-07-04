using System.Text.Json;
using Newtonsoft.Json;

public class BaseTest
{
    protected AccountService accountService = null!;
    protected BookStoreService bookStoreService = null!;
    protected BookModel book = null!;
    protected AccountModel account = null!;
    protected ReplaceBookModel replaceBook = null!;

    protected string token = null!;

    [SetUp]
    public async Task Setup()
    {
        accountService = new AccountService();
        bookStoreService = new BookStoreService();

        account = JsonUtils.ReadJson<AccountModel>(
            "Data/TestData",
            "UserData.json"
        );

        var response = await accountService.GenerateToken(
            account.Username!,
            account.Password!
        );

        book = JsonUtils.ReadJson<BookModel>(
            "Data/TestData",
            "BookData.json"
        );

        replaceBook = JsonUtils.ReadJson<ReplaceBookModel>(
            "Data/TestData",
            "ReplaceBookData.json"
        );

        // var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(
        //     response.Content!
        // );

        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(
            response.Content!
        );


        token = tokenResponse!.Token!;
    }

    protected async Task<AccountResponse> GetAccount()
    {
        var response = await accountService.GetAccountById(
            token,
            account.UserId!
        );

        return JsonConvert.DeserializeObject<AccountResponse>(
            response.Content!
        )!;
    }
}