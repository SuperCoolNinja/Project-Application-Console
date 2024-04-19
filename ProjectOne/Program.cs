using ProjectOne.Static;

namespace ProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Logger.ConfigurePath("C:\\Users\\...\\Desktop\\log.txt");

            Logger.Write("I love banana");

            Logger.Read();
        }
    }
}
