using ProjectOne.Static.Manager;

namespace ProjectOne.Static.Utility;


/// <summary>
/// Contains functionalities for reading from and writing to log files.
/// </summary>
internal static class Logger
{
    private const string DEFAULT_LOGGER_FILE_NAME = "application.log";
    private static string _path;

    /// <summary>
    /// Initialize logger with the path where the JSON file is located.
    /// </summary>
    /// <param name="jsonFilePath">The path of the JSON file.</param>
    public static void InitializeLogger(string jsonFilePath)
    {
        _path = Path.Combine(Path.GetDirectoryName(jsonFilePath), DEFAULT_LOGGER_FILE_NAME);
    }

    /// <summary>
    /// Writes a log message to a log file.
    /// </summary>
    /// <param name="message">the actual log message.</param>
    public static void Write(in string message)
    {
        DateTime dateTime = DateTime.Now;
        var date = dateTime.ToString("yyyy-MM-dd HH-mm-ss");

        try
        {
            using (StreamWriter sw = !File.Exists(_path) ? File.CreateText(_path) : File.AppendText(_path))
                sw.WriteLine(date + " " + message);
        }
        catch
        {
            Console.WriteLine("Cannot create log file because the path set is not valid.");
            ApplicationManager.IsExiting = true;
        }

    }
}