namespace ProjectOne.Entities;

internal class Student
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Birthday { get; init; }
    public List<Grade> GradesList { get; set; }

    public Student(string firstName, string lastName, string birthday)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        GradesList = new List<Grade>(); 
    }
}
