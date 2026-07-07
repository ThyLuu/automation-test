public static class FileResolver
{
    private static readonly string BaseFolder =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData");

    public static string Resolve(string fileName)
    {
        return Path.Combine(BaseFolder, fileName);
    }
}