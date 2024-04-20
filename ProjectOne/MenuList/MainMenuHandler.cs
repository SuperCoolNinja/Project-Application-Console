using ProjectOne.Static.Manager;
using ProjectOne.Static.Utility;

internal class MainMenuHandler : Menu
{
    protected override string Title => "Main Menu";

    protected override List<string> MenuOptions => new List<string>() { "Menu Students", "Menu Courses", "Exit" };

    public override Menu ManageOptions(int option)
    {
        switch (option)
        {
            case 1:
                Logger.Write($"[{Title}] - Select Menu Students");
                return new StudentMenuHandler();
            case 2:
                Logger.Write($"[{Title}] - Select Menu Courses");
                return new CourseMenuHandler();
            case 3:
                Logger.Write($"[{Title}] - Select Exit");
                ApplicationManager.IsExiting = true;
                return this;
            default:
                Logger.Write($"[{Title}] - Invalid option, try again.");
                return this;
        }
    }

}
