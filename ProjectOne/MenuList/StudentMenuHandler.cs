using ProjectOne.Entities;
using ProjectOne.Static.Manager;
using ProjectOne.Static.Utility;
internal class StudentMenuHandler : Menu
{
    protected override string Title => "Student Menu";
    protected override List<string> MenuOptions => new List<string>() { "Show List", "Create", "Show Info", "Add Note", "Main Menu" };

    private void ShowAllStudent()
    {
        ConsoleInterface.ShowAllStudent();
    }

    private Student? GetStudentByID(int id)
    {
        return ApplicationManager.Students.FirstOrDefault(student => student.Id == id);
    }

    private void ShowStudentInfo()
    {
        int id = ConsoleInterface.AskUserID();
        Student? student = GetStudentByID(id);

        if (student == null)
        {
            Logger.Write($"[{Title}] - Student not found.");
            return;
        }

        ConsoleInterface.ShowUserData(student);
        Logger.Write($"[{Title}] - Show student info");
    }

    private void CreateNewStudent()
    {
        (string? firstname, string? lastname, string? birthday) = ConsoleInterface.AskStudentInfo();

        if (InputValidator.AnyNullOrEmpty(firstname, lastname, birthday))
        {
            Logger.Write("[StudentMenu] - Creation of student canceled.");
            return;
        }

        Student student = new Student(firstname, lastname, birthday);
        ApplicationManager.Students.Add(student);

        Logger.Write($"[{Title}] - Created new student");
    }

    public override Menu ManageOptions(int option)
    {
        switch (option)
        {
            case 1:
                ShowAllStudent();
                Logger.Write($"[{Title}] - Show student list ");
                return this;
            case 2:
                CreateNewStudent();
                return this;
            case 3:
                ShowStudentInfo();
                return this;
            case 4:
                Logger.Write($"[{Title}] - Add note");
                return this;
            case 5:
                Logger.Write($"[{Title}] - Back to Main Menu");
                return new MainMenuHandler();
            default:
                Logger.Write($"[{Title}] - Invalid option, try again.");
                return this;
        }
    }
}