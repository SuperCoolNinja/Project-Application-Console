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
}