using ProjectOne.Entities;
using ProjectOne.Static.Utility;
internal class StudentMenuHandler : Menu
{
    protected override string Title => "Student Menu";
    protected override List<string> MenuOptions => new List<string>() { "Show List", "Create", "Show Info", "Add Note", "Main Menu" };


    private void ShowStudent(Student student)
    {

    }

    public override Menu ManageOptions(int option)
    {
        switch (option)
        {
            case 1:
                Logger.Write("Show student list ");
                return this;
            case 2:
                Logger.Write("Create new student");
                return this;
            case 3:
                Logger.Write("Show student info");
                return this;
            case 4:
                Logger.Write("Add note");
                return this;
            case 5:
                Logger.Write("Back to Main Menu");
                return new MainMenuHandler();
            default:
                Logger.Write($"[{Title}] - Invalid option, try again.");
                return this;
        }
    }

}
