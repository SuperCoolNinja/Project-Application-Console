using ProjectOne.Static.Manager;
using ProjectOne.Static.Utility;


namespace ProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Please set a valid path where is located the data.json file to load.");
                return;
            }

            ApplicationManager.ConfigurePath(args[0]);

            ApplicationManager.Initialize();

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
