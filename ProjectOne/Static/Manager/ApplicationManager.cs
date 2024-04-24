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
    private static string _jsonFilePath;

    public static List<Student> Students { get { return _students; } }
    public static List<Course> Courses { get { return _courses; } }
    public static List<Grade> Grades { get { return _grades; } }

    public static bool IsExiting { get; set; } = false;
    public static bool ShouldNotClose() => !IsExiting;

    public static void Initialize(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
        Logger.InitializeLogger(jsonFilePath);
        LoadData(jsonFilePath);
    }

    private static void LoadData(string jsonFilePath)
    {
        var data = JsonPersistance.LoadData(jsonFilePath);
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

    public static void SaveData(string jsonFilePath)
    {
        var fileName = Path.GetFileNameWithoutExtension(jsonFilePath);
        var data = new DataModel
        {
            Students = _students,
            Courses = _courses,
            Grades = _grades
        };

        JsonPersistance.SaveData(data, fileName);

        Logger.Write("Data saved successfully");
    }
}