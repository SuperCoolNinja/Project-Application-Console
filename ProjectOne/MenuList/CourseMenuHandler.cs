using ProjectOne.Entities;
using ProjectOne.Static.Manager;
using ProjectOne.Static.Utility;

internal class CourseMenuHandler : Menu
{
    protected override string Title => "Course Menu";

    protected override List<string> MenuOptions => new List<string>() { "Show List", "Create", "Delete", "Main Menu" };

    private void ShowAllCourses()
    {
        ConsoleInterface.ShowAllCourses();
    }

    private void CreateNewCourse()
    {
        string? name = ConsoleInterface.AskCourseInfo();

        if (InputValidator.AnyNullOrEmpty(name))
        {
            Logger.Write("[CourseMenu] - Creation of course canceled.");
            return;
        }

        Course course = new Course(name);
        ApplicationManager.Courses.Add(course);

        ApplicationManager.SaveData();

        Logger.Write($"[{Title}] - Created new course");
    }

    private void DeleteCourse()
    {
        int courseId = ConsoleInterface.AskCourseID();
        Course? course = ApplicationManager.Courses.FirstOrDefault(c => c.Id == courseId);

        if (course == null)
        {
            Logger.Write($"[{Title}] - Course not found.");
            return;
        }

        ApplicationManager.Courses.Remove(course);

        foreach (var student in ApplicationManager.Students)
        {
            var gradeToRemove = student.GradesList.FirstOrDefault(g => g.CourseId == courseId);

            if (gradeToRemove != null)
            {
                student.GradesList.Remove(gradeToRemove);
            }
        }

        ApplicationManager.SaveData();

        Logger.Write($"[{Title}] - Deleted course and associated grades");
    }

    public override Menu ManageOptions(int option)
    {
        switch (option)
        {
            case 1:
                ShowAllCourses();
                Logger.Write($"[{Title}] - Show courses list");
                return this;
            case 2:
                CreateNewCourse();
                return this;
            case 3:
                DeleteCourse();
                return this;
            case 4:
                Logger.Write($"[{Title}] - Back to Main Menu");
                return new MainMenuHandler();
            default:
                Logger.Write($"[{Title}] - Invalid option, try again.");
                return this;
        }
    }
}
