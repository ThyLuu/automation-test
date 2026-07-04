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

        var baseUrl = configuration["TestUrl"]
            ?? throw new InvalidOperationException("TestUrl is missing in appsettings.json");

        client = new RestClient(baseUrl);

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