namespace ProjectOne.Entities;

internal class Student
{
    public int Id { get; private set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Birthday { get; init; }
    public List<Grade> GradesList { get; set; }

    private static int _nextId = 1;

    public Student(string firstName, string lastName, string birthday)
    {
        Id = _nextId++;
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        GradesList = new List<Grade>();
    }

    /// <summary>
    /// Adds a grade to the student's list of grades.
    /// </summary>
    /// <param name="grade">The grade to add.</param>
    public void AddGrade(Grade grade)
    {
        GradesList.Add(grade);
    }
}