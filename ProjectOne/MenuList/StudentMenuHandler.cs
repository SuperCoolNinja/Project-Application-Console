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

        ApplicationManager.SaveData();

        Logger.Write($"[{Title}] - Created new student");
    }

    private void AddNote()
    {
        int studentId = ConsoleInterface.AskUserID();
        Student? student = GetStudentByID(studentId);

        if (student == null)
        {
            Logger.Write($"[{Title}] - Student not found.");
            return;
        }

        int courseId = ConsoleInterface.AskCourseID();
        int note = ConsoleInterface.AskNote();
        string commentary = ConsoleInterface.AskCommentary();

        var existingGrade = student.GradesList.FirstOrDefault(g => g.CourseId == courseId);

        if (existingGrade != null)
        {
            existingGrade.Note = note;
            existingGrade.Commentary = commentary;

            Logger.Write($"[{Title}] - Updated existing grade for the course.");
        }
        else
        {
            Grade newGrade = new Grade(courseId, note, commentary);
            student.AddGrade(newGrade);

            Logger.Write($"[{Title}] - Added new grade to student.");
        }

        ApplicationManager.SaveData();
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
                AddNote();
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