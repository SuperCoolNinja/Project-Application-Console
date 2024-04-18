using ProjectOne.Static;

namespace ProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Write("Toto message !");


            //Testing with default path : 
            Logger.Read();

            //Testing with specific path : 
            Logger.Read("C:\\toto.txt");
        }
    }
}
