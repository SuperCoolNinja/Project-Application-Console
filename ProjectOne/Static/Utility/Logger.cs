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
    /// Combine the default path with the name of the logger file.
    /// </summary>
    static Logger()
    {
        _path = Path.Combine(ApplicationManager.Path, DEFAULT_LOGGER_FILE_NAME);
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }


    /// <summary>
    /// Reads a log message from a log file.
    /// </summary>
    public static void Read()
    {
        if (!File.Exists(_path))
        {
            Console.WriteLine("File not found !");
            return;
        }

        try
        {
            using (StreamReader sr = File.OpenText(_path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                    Console.WriteLine(s);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
