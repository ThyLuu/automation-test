using FluentAssertions;
using NUnit.Framework;
using System.Net;

namespace UserTests;

public class UserTests : BaseTest
{
    [Test]
    public async Task VerifyGetUserSuccessfully()
    {
        var response = await userService.GetUsers(token);

        Console.WriteLine(response.Content);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNullOrEmpty();

        // verify schema
        ValidatorSchema.ValidateSchema(
            response.Content!,
            "GetUserListSchema.json")
        ;
    }

    [Test]
    public async Task VerifyGetUserByIdSuccessfully()
    {
        string email = createUserData.email;

        var getUsersResponse = await userService.GetUserByEmail(token, email);
        int userId = UserHelper.GetUserIdByEmail(getUsersResponse.Content!, email);

        var response = await userService.GetUserById(token, userId);

        Console.WriteLine(response.Content);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNullOrEmpty();
        response.Content.Should().Contain(email);

        // verify schema
        ValidatorSchema.ValidateSchema(
            response.Content!,
            "GetUserByIdSchema.json"
        );
    }

    [Test]
    public async Task VerifyCreateUserSuccessfully()
    {
        var request = JsonUtils.ReadJson<CreateUserRequest>(
            "TestData",
            "CreateUserData.json"
        );

        var response = await userService.CreateUser(token, request);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.Content.Should().NotBeNullOrEmpty();

        // verify schema
        ValidatorSchema.ValidateSchema(
            response.Content!,
            "CreateUserSchema.json"
        );

        // verify data after add user
        var getUserResponse = await userService.GetUserByEmail(token, request.email);
        getUserResponse.Content.Should().Contain(request.name);
        getUserResponse.Content.Should().Contain(request.email);
        getUserResponse.Content.Should().Contain(request.gender);
        getUserResponse.Content.Should().Contain(request.status);
    }

    [Test]
    public async Task VerifyUpdateUserSuccessfully()
    {
        string email = createUserData.email;

        var getUsersResponse = await userService.GetUserByEmail(token, email);
        int userId = UserHelper.GetUserIdByEmail(getUsersResponse.Content!, email);

        var updateRequest = JsonUtils.ReadJson<UpdateUserRequest>(
            "TestData",
            "UpdateUserData.json"
        );

        var response = await userService.UpdateUser(token, userId, updateRequest);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNullOrEmpty();

        ValidatorSchema.ValidateSchema(
            response.Content!,
            "UpdateUserSchema.json"
        );

        // verify data after update user
        var getUserResponse = await userService.GetUserById(token, userId);

        getUserResponse.Content.Should().Contain(updateRequest.name);
        getUserResponse.Content.Should().Contain(updateRequest.status);
    }

    [Test]
    public async Task VerifyDeleteUserSuccessfully()
    {
        string email = createUserData.email;

        var getUsersResponse = await userService.GetUserByEmail(token, email);
        int userId = UserHelper.GetUserIdByEmail(getUsersResponse.Content!, email);

        var response = await userService.DeleteUser(token, userId);

        // verify status
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // verify data after delete user
        var getUserResponse = await userService.GetUserByEmail(token, email);
        getUserResponse.Content.Should().NotContain(email);
    }
}
