using ProjectOne.Static.Manager;
using ProjectOne.Static.Utility;

namespace ProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationManager.ConfigurePath("C:\\Users\\sbpro\\Desktop\\data\\");

            Menu menu = new MainMenuHandler();

            while (ApplicationManager.ShouldNotClose())
            {
                Console.Clear();

                menu.Render();

                int userOptionChoice = ConsoleInterface.AskUserOption();

                menu = menu.ManageOptions(userOptionChoice);
            }

            JsonPersistance.SaveData(new object[] { 5, true, "testing" }, "data");

            Logger.Write("Application terminated successfully.");
        }
    }
}
