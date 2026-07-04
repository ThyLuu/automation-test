# RestSharp NUnit API Testing - GoRest

This project validates the GoRest `/public-api/users` endpoint using NUnit and RestSharp.

## Structure

- `API/ApiClient.cs` - shared HTTP client abstraction
- `Core/SchemaValidator.cs` - lightweight JSON schema validation logic
- `Service/UserService.cs` - user endpoint operations
- `Model/` - request and response payload models
- `Test/` - NUnit tests and global hook setup
- `Schema/` - JSON schema definitions for response validation
- `Configuration/appsettings.json` - base URL and token configuration

## Test coverage

- `GetUsers_ShouldReturnValidUsersAndMeta` verifies the GET endpoint returns:
  - `200 OK`
  - non-empty `meta.total`, `meta.page`, `meta.limit`
  - each user contains `id`, `name`, `email`, `gender`, `status`
- `UpdateUser_ShouldReturnResponseMatchingSchema` verifies update flow:
  - creates a new user
  - updates a user field
  - validates the response against `Schema/user-update-response-schema.json`

## Run tests

From the `restsharp/practice/ThyThyLuu` folder:

```bash
dotnet test ThyThyLuu.csproj
```

## Notes

- Configuration is loaded using `ConfigurationUtils.ReadConfiguration("appsettings.json")` in `Test/BaseTest.cs`
- `SchemaValidator` performs schema checks without external JSON schema libraries
- The project follows a clean Core/Service/Test structure and centralizes HTTP logic in `ApiClient`
