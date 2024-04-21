namespace ProjectOne.Entities;

internal class Student
{
    //Todo change the id generation to load from json data and increment from the last one added.
    private static int _nextId = 1;
    
    public int Id { get; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Birthday { get; init; }
    public List<Grade> GradesList { get; set; }

    public Student(string firstName, string lastName, string birthday)
    {
        Id = _nextId++;
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        GradesList = new List<Grade>();
    }
}
