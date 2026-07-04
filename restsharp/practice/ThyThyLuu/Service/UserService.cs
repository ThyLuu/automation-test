using RestSharp;

public class UserService
{
    private ApiClient _apiClient;

    public UserService()
    {
        _apiClient = new ApiClient();
    }
    
    public async Task<RestResponse> GetUsers(string token)
    {
        var request = new RestRequest("/public/v2/users", Method.Get);

        return await _apiClient.ExecuteAsync(request, token);
    }

    public async Task<RestResponse> GetUserById(string token, int userId)
    {
        var request = new RestRequest($"/public/v2/users/{userId}", Method.Get);

        return await _apiClient.ExecuteAsync(request, token);
    }

    public async Task<RestResponse> CreateUser(string token, CreateUserRequest body)
    {
        var request = new RestRequest("/public/v2/users", Method.Post);

        request.AddJsonBody(body);

        return await _apiClient.ExecuteAsync(request, token);
    }

    public async Task<RestResponse> UpdateUser(string token, int userId, UpdateUserRequest body)
    {
        var request = new RestRequest($"/public/v2/users/{userId}", Method.Put);

        request.AddJsonBody(body);

        return await _apiClient.ExecuteAsync(request, token);
    }

    public async Task<RestResponse> DeleteUser(string token, int userId)
    {
        var request = new RestRequest($"/public/v2/users/{userId}", Method.Delete);

        return await _apiClient.ExecuteAsync(request, token);
    }

    public async Task<RestResponse> GetUserByEmail(string token, string email)
    {
        var request = new RestRequest("/public/v2/users", Method.Get);

        request.AddQueryParameter(
            "email",
            email
        );

        return await _apiClient.ExecuteAsync(request, token);
    }
}

