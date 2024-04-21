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

    private void CreateNewStudent()
    {
        (string? firstname, string? lastname, string? birthday) = ConsoleInterface.AskStudentInfo();

        if(InputValidator.AnyNullOrEmpty(firstname,  lastname, birthday)) 
        {
            Console.Clear();
            Logger.Write("[StudentMenu] - Creation of student canceled.");
            return;
        }

        Student student = new Student(firstname, lastname, birthday);

        _students.Add(student);

        Logger.Write($"[{Title}] - Created new student");
        Console.Clear();
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
                Logger.Write($"[{Title}] - Show student info");
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
