using RestSharp;

public class BookStoreService
{
    private ApiClient _apiClient;

    public BookStoreService()
    {
        _apiClient = new ApiClient();
    }

    public async Task<RestResponse> AddBook(string token,AddBookRequest requestBody)
    {
        var request = new RestRequest("/BookStore/v1/Books", Method.Post);

        request.AddJsonBody(requestBody);

        return await _apiClient.ExecuteAsync(request, token);
    }

    public async Task<RestResponse> ReplaceBook(string token ,string currentIsbn, ReplaceBookRequest requestBody)
    {
        var request = new RestRequest($"BookStore/v1/Books/{currentIsbn}", Method.Put);

        request.AddJsonBody(requestBody);

        return await _apiClient.ExecuteAsync(request, token);
    }

    public async Task<RestResponse> DeleteBook(string token, string userId)
    {
        var request = new RestRequest("/BookStore/v1/Books", Method.Delete);

        request.AddQueryParameter(
            "UserId",
            userId
        );

        return await _apiClient.ExecuteAsync(request, token);
    }
}