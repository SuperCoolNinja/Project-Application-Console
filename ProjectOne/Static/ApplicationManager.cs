namespace ProjectOne.Static;

internal static class ApplicationManager
{
    private const string DEFAULT_PATH = "./log.txt";
    public static string Path { get; set; } = DEFAULT_PATH;

    public static bool IsExiting { get; set; } = false;
    public static bool ShouldNotClose() => IsExiting == false;

    public static void ConfigurePath(string path)
    {
        Path = path;
    }
}
