using Newtonsoft.Json;
using System.Reflection;

public class JsonUtils
{
    public static T ReadJson<T>(string folderName, string fileName)
    {
        string json = ReadJsonFile(folderName, fileName);

        return JsonConvert.DeserializeObject<T>(json)!;
    }

    public static string ReadJsonFile(string folderName, string fileName)
    {
        string assemblyPath = AppDomain.CurrentDomain.BaseDirectory;

        string relativePath = Path.Combine(folderName, fileName);

        // window:
        // relativePath

        // mac:
        // relativePath
        //     .Replace('\\', Path.DirectorySeparatorChar)
        //     .Replace('/', Path.DirectorySeparatorChar)

        string normalizedPath =
            relativePath
                .Replace('\\', Path.DirectorySeparatorChar)
                .Replace('/', Path.DirectorySeparatorChar);

        string filePath = Path.Combine(assemblyPath, normalizedPath);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(
                $"JSON file not found: {filePath}"
            );
        }

        return File.ReadAllText(filePath);
    }
}