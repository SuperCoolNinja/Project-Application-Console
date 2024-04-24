using ProjectOne.Entities;
using ProjectOne.Models;
using ProjectOne.Static.Utility;

namespace ProjectOne.Static.Manager;


/// <summary>
/// Adds some functionalities to be able to manage the application easily.
/// </summary>
internal static class ApplicationManager
{
    private static List<Student> _students = new List<Student>();
    private static List<Course> _courses = new List<Course>();
    private static List<Grade> _grades = new List<Grade>();
    public static string FilePath { get; private set; }

    public static List<Student> Students { get { return _students; } }
    public static List<Course> Courses { get { return _courses; } }
    public static List<Grade> Grades { get { return _grades; } }

    public static bool IsExiting { get; set; } = false;
    public static bool ShouldNotClose() => !IsExiting;

    public static void Initialize(string jsonFilePath)
    {
        FilePath = jsonFilePath;
        Logger.InitializeLogger(jsonFilePath);
        LoadData();
    }

    private static void LoadData()
    {
        var data = JsonPersistance.LoadData();
        if (data != null)
        {
            _students = data.Students;
            _courses = data.Courses;
            _grades = data.Grades;

            Logger.Write("Data loaded successfully.");
        }
        else
        {
            Logger.Write("No data found.");
        }
    }

    public static void SaveData()
    {
        var data = new DataModel
        {
            Students = _students,
            Courses = _courses,
            Grades = _grades
        };

        JsonPersistance.SaveData(data);

        Logger.Write("Data saved successfully");
    }
}
