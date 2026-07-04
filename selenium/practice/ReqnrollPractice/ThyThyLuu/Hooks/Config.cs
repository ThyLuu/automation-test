using Microsoft.Extensions.Configuration;

public static class Config
{
    private static readonly IConfigurationRoot configuration =
        new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

    public static string BaseUrl =>
        configuration["BaseUrl"] ?? string.Empty;
}