using System.IO;

namespace ProjectOne.Static;

internal static class Logger
{
    private const string _Path = "./";
    private const string _FileName = "log";
    private const string _Extension = "txt";
    private const string _FullPath = _Path + _FileName + "." + _Extension;

    public static void Write(in string message, in string path = _FullPath)
    {
        DateTime dateTime = DateTime.Now;
        var date = dateTime.ToString("yyyy-MM-dd HH-mm-ss");


        if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(date + " " + message);
            }
        }
        else
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(date + " " + message);
            }
        }
    }

    public static void Read(in string fullPath = _FullPath)
    {
        using (StreamReader sr = File.OpenText(fullPath))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
                Console.WriteLine(s);
        }
    }
}
