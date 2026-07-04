using RestSharp;

public class AccountService
{
    private ApiClient _apiClient;

    public AccountService()
    {
        _apiClient = new ApiClient();
    }

    public async Task<RestResponse> Authorized(string username, string password)
    {
        var request = new RestRequest($"/Account/v1/Authorized", Method.Post);

        request.AddJsonBody(new
        {
            userName = username,
            password = password,
        });

        return await _apiClient.ExecuteAsync(request);
    }

    public async Task<RestResponse> GenerateToken(string username, string password)
    {
        var request = new RestRequest($"/Account/v1/GenerateToken", Method.Post);

        request.AddJsonBody(new
        {
            userName = username,
            password = password,
        });

        return await _apiClient.ExecuteAsync(request);
    }

    public async Task<RestResponse> GetAccountById(string token, string userId)
    {
        var request = new RestRequest($"/Account/v1/User/{userId}", Method.Get);

        return await _apiClient.ExecuteAsync(request, token);
    }
}