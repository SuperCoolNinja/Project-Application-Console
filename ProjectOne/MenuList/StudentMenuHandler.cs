using ProjectOne.Entities;
using ProjectOne.Static.Utility;
internal class StudentMenuHandler : Menu
{
    protected override string Title => "Student Menu";
    protected override List<string> MenuOptions => new List<string>() { "Show List", "Create", "Show Info", "Add Note", "Main Menu" };

    private List<Student> _students = new List<Student>();

    private void ShowAllStudent()
    {
        ConsoleInterface.ShowStudentList(_students);
    }

    private bool DoesIndexExist(int id)
    {
        return _students.Any(v => v.Id == id);
    }

    private Student? GetStudentByID(int id)
    {
        Student student = null;
        try
        {
            student = _students.Find(v => v.Id == id);
        }
        catch (Exception ex)
        {
            Logger.Write($"[Student Menu] - {ex.Message}");
        }

        return student;
    }

    private void ShowStudentInfo()
    {
        int id = ConsoleInterface.AskUserID();
        bool indexFound = DoesIndexExist(id);

        if (!indexFound)
        {
            Logger.Write($"[{Title}] - Student not found.");
            return;
        }

        var student = GetStudentByID(id);

        if (student == null)
            return;

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

        _students.Add(student);

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
