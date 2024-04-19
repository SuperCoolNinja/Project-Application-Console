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

                int userOptionChoice = ConsoleInterface.GetUserOption();

                //switch (userOptionChoice)
                //{
                //    case 0:
                //        menu = new StudentMenu();
                //        break;
                //    case 1:
                //        menu = new CourseMenu();
                //        break;
                //    case 2:
                //        isRendering = false;
                //        Console.WriteLine("Fin du program.");
                //        break;
                //}
            }

        }
    }
}
