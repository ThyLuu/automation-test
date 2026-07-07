using Newtonsoft.Json;
using System.Reflection;

public class JsonUtils
{
    public static T ReadJson<T>(string fileName)
    {
        string assemblyPath = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location
        )!;

        string filePath = Path.Combine(
            assemblyPath,
            "TestData",
            fileName
        );

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(
                $"JSON file not found: {filePath}"
            );
        }

        string json = File.ReadAllText(filePath);

        return JsonConvert.DeserializeObject<T>(json)!;
    }
}
