using ProjectOne.Static;

namespace ProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Logger.ConfigurePath("C:\\Users\\...\\Desktop\\log.txt");
            //Logger.Write("I love banana");

            Menu menu = new MainMenuHandler();
            bool isRendering = true;

            while (isRendering)
            {
                Console.Clear();

                menu.Render();

                int userOptionChoice = ConsoleInterface.AskUserOption();

                menu = menu.ManageOptions(userOptionChoice, ref isRendering);
            }

            Console.WriteLine("Fin du program.");

        }
    }
}
