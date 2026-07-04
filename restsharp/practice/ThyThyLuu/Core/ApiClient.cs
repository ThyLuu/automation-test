using Microsoft.Extensions.Configuration;
using RestSharp;

public class ApiClient
{
    protected RestClient client;
    
    public ApiClient()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var baseUrl = configuration["TestUrl"];

        client = new RestClient(baseUrl);
    }

    public async Task<RestResponse> ExecuteAsync(RestRequest request, string? token = null)
    {
        request.AddHeader(
            "Content-Type",
            "application/json"
            );

        if (!string.IsNullOrEmpty(token))
        {
            request.AddHeader(
                "Authorization",
                $"Bearer {token}");
        }

        return await client.ExecuteAsync(request);
    }
}