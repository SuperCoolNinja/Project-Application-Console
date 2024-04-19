namespace ProjectOne.Static;

internal static class Logger
{
    private static string _path = "";
    static Logger()
    {
        _path = ApplicationManager.Path;
    }

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
