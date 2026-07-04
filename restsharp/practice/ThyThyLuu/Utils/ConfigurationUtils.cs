using Microsoft.Extensions.Configuration;

public static class ConfigurationUtils
{
    private static IConfigurationRoot? _config;

    public static void ReadConfiguration(string path)
    {
        _config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            // window: path
            // mac: path.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar)
            .AddJsonFile(path.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar))
            .Build();
    }

    public static string GetConfigurationByKey(string key, IConfiguration? config = null)
    {
        var value = config == null ? _config[key] : config[key];

        if (!string.IsNullOrEmpty(value))
        {
            return value;
        }

        throw new InvalidDataException($"Attribute [{key}] is not been set in appsettings.json");
    }

    public static string GetString(string key)
    {
        return _config?[key]
            ?? throw new Exception($"Cannot find config key: {key}");
    }

    public static int GetInt(string key)
    {
        return int.Parse(
            _config?[key]
            ?? throw new Exception($"Cannot find config key: {key}")
        );
    }
}