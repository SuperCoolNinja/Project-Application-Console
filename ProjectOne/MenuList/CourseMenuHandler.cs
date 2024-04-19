
using ProjectOne.Static;

internal class CourseMenuHandler : Menu
{
    protected override string Title => "Courses Menu";

    protected override List<string> MenuOptions => new List<string>() { "Show List", "Create", "Delete", "Main Menu" };

    public override Menu ManageOptions(int option)
    {
        switch (option)
        {
            case 1:
                Logger.Write("Show courses list");
                return this;
            case 2:
                Logger.Write("Create new course");
                return this;
            case 3:
                Logger.Write("Delete new course");
                return this;
            case 4:
                Logger.Write("back to Main Menu");
                return new MainMenuHandler();
            default:
                Logger.Write($"[{Title}] - Invalid option, try again.");
                return this;
        }
    }
}
