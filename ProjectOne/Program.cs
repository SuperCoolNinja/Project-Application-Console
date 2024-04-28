using ProjectOne.Static.Manager;
using ProjectOne.Static.Utility;


namespace ProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a valid path where the .json file is located.");
                Console.ReadKey();
                return;
            }


            string jsonFilePath = args[0];

            ApplicationManager.Initialize(jsonFilePath);

            Menu menu = new MainMenuHandler();

            while (ApplicationManager.ShouldNotClose())
            {
                menu.Render();

                int userOptionChoice = ConsoleInterface.AskUserOption();

                menu = menu.ManageOptions(userOptionChoice);
            }

            Logger.Write("Application terminated successfully.");
        }
    }
}
