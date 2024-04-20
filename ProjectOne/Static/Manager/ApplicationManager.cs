namespace ProjectOne.Static.Manager;


/// <summary>
/// Adds some functionalities to be able to manage the application easily.
/// </summary>
internal static class ApplicationManager
{
    private const string DEFAULT_PATH = "./";

    public static string Path { get; set; } = DEFAULT_PATH;

    public static bool IsExiting { get; set; } = false;
    public static bool ShouldNotClose() => IsExiting == false;

    public static void ConfigurePath(string path)
    {
        Path = path;
    }
}
