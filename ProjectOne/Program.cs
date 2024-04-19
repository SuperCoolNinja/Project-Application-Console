using ProjectOne.Static;

namespace ProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ApplicationManager.ConfigurePath("C:\\log.txt");

            Menu menu = new MainMenuHandler();

            while (ApplicationManager.ShouldNotClose())
            {
                Console.Clear();

                menu.Render();

                int userOptionChoice = ConsoleInterface.AskUserOption();

                menu = menu.ManageOptions(userOptionChoice);
            }

            Logger.Write("Application terminated successfully.");
        }
    }
}
