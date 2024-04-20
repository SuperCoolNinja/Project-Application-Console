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
                return new StudentMenuHandler();
            case 2:
                return new CourseMenuHandler();
            case 3:
                ApplicationManager.IsExiting = true;
                return this;
            default:
                Logger.Write($"[{Title}] - Invalid option, try again.");
                return this;
        }
    }

}
