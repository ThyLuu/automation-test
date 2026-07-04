using FluentAssertions;
using Newtonsoft.Json;
using System.Net;

namespace Jira008Test;

public class AccountTests : BaseTest
{
    [Test]
    public async Task VerifyGetAccountByIdSuccessfully()
    {
        string userId = account.UserId!;

        var response = await accountService.GetAccountById(token, userId);
        var result = JsonConvert.DeserializeObject<AccountResponse>(response.Content!);

        Console.WriteLine(response.Content);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNullOrEmpty();
        response.Content.Should().Contain(userId.ToString());

        // verify schema
        ValidatorSchema.ValidateSchema(
            response.Content!,
            "GetAccountByIdSchema.json"
        );

        // verify data
        result.Should().NotBeNull();
        result.UserId.Should().Be(account.UserId);
        result.Username.Should().Be(account.Username);
    }

    [Test]
    public async Task VerifyGetAccountByIdUnsuccessfully()
    {
        string invalidUserId = Guid.NewGuid().ToString();

        var response = await accountService.GetAccountById(
            token,
            invalidUserId
        );

        Console.WriteLine(response.Content);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        response.Content.Should().NotBeNullOrEmpty();

        var result = JsonConvert.DeserializeObject<ErrorResponse>(
            response.Content!
        );

        result.Should().NotBeNull();
        result!.Code.Should().Be("1207");
        result.Message.Should().Contain("User not found");
    }
}
