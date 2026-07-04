using FluentAssertions;
using Newtonsoft.Json;
using System.Net;

namespace Jira008Test;

public class BookStoreTest : BaseTest
{
    [Test]
    public async Task VerifyAddBookSuccessfully()
    {
        var requestBody = new AddBookRequest
        {
            UserId = account.UserId,
            CollectionOfIsbns =
            [
                new IsbnItem
                {
                    Isbn = book.Isbn
                }
            ]
        };

        var response = await bookStoreService.AddBook(token, requestBody);
        var result = JsonConvert.DeserializeObject<AddBookResponse>(
            response.Content!
        );

        Console.WriteLine(response.Content);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.Content.Should().NotBeNullOrEmpty();

        result.Should().NotBeNull();
        result!.Books.Should().ContainSingle();
        result.Books!.First().Isbn.Should().Be(book.Isbn);

        // verify schema
        ValidatorSchema.ValidateSchema(response.Content!, "AddBookSchema.json");

        // verify data after add book
        var accountResponse = await GetAccount();

        accountResponse.Books.Should().Contain(
            x => x.Isbn == book.Isbn
        );
    }

    [Test]
    public async Task VerifyReplaceBookSuccessfully()
    {
        var requestBody = new ReplaceBookRequest
        {
            UserId = account.UserId,
            Isbn = replaceBook.NewIsbn
        };

        var response = await bookStoreService.ReplaceBook(token, replaceBook.CurrentIsbn!, requestBody);
        var result = JsonConvert.DeserializeObject<ReplaceBookResponse>(
            response.Content!
        );

        Console.WriteLine(response.Content);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        result.Should().NotBeNull();
        result!.UserId.Should().Be(account.UserId);
        result.Books!.First().Isbn.Should().Be(replaceBook.NewIsbn);

        // verify schema
        ValidatorSchema.ValidateSchema(response.Content!, "ReplaceBookSchema.json");

        // Verify data after replace book
        var accountResponse = await GetAccount();

        accountResponse.Books.Should().Contain(
            x => x.Isbn == replaceBook.NewIsbn
        );

        accountResponse.Books.Should().NotContain(
            x => x.Isbn == replaceBook.CurrentIsbn
        );
    }

    [Test]
    public async Task VerifyDeleteBookSuccessfully()
    {
        var response = await bookStoreService.DeleteBook(token, account.UserId!);

        Console.WriteLine(response.Content);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        response.Content.Should().BeNullOrEmpty();

        // Verify data after delete book
        var accountResponse = await GetAccount();

        accountResponse.Books.Should().NotContain(
            x => x.Isbn == book.Isbn
        );
    }

    [Test]
    public async Task VerifyAddBookUnsuccessfully()
    {
        var requestBody = new AddBookRequest
        {
            UserId = account.UserId,
            CollectionOfIsbns =
            [
                new IsbnItem
                {
                    Isbn = "invalid-isbn"
                }
            ]
        };

        var response = await bookStoreService.AddBook(
            token,
            requestBody
        );

        Console.WriteLine(response.Content);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        response.Content.Should().NotBeNullOrEmpty();

        var result = JsonConvert.DeserializeObject<ErrorResponse>(
            response.Content!
        );

        result.Should().NotBeNull();

        // verify data after add book unsuccessfully
        var accountResponse = await GetAccount();

        accountResponse.Books.Should().NotContain(
            x => x.Isbn == "invalid-isbn"
        );
    }

    [Test]
    public async Task VerifyReplaceBookUnsuccessfully()
    {
        var requestBody = new ReplaceBookRequest
        {
            UserId = account.UserId,
            Isbn = "invalid-isbn"
        };

        var response = await bookStoreService.ReplaceBook(
            token,
            replaceBook.CurrentIsbn!,
            requestBody
        );

        Console.WriteLine(response.Content);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        response.Content.Should().NotBeNullOrEmpty();

        var result = JsonConvert.DeserializeObject<ErrorResponse>(
            response.Content!
        );

        result.Should().NotBeNull();

        // verify data after replace unsuccessfully
        var accountResponse = await GetAccount();

        accountResponse.Books.Should().NotContain(
            x => x.Isbn == "invalid-isbn"
        );

        result.Should().NotBeNull();
        result!.Code.Should().Be("1205");
        result.Message.Should().Contain("ISBN supplied is not available in Books Collection!");
    }

    [Test]
    public async Task VerifyDeleteBookUnsuccessfully()
    {
        string invalidUserId = Guid.NewGuid().ToString();

        var response = await bookStoreService.DeleteBook(
            token,
            invalidUserId
        );

        Console.WriteLine(response.Content);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        response.Content.Should().NotBeNullOrEmpty();

        var result = JsonConvert.DeserializeObject<ErrorResponse>(
            response.Content!
        );

        result.Should().NotBeNull();

        // verify data was not deleted
        var accountResponse = await GetAccount();
        accountResponse.Should().NotBeNull();

        result.Should().NotBeNull();
        result!.Code.Should().Be("1207");
        result.Message.Should().Contain("User Id not correct!");
    }
}
