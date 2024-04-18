namespace ProjectOne.Entities;

internal class Student
{
    Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Birthday { get; init; }

    public Student(string firstName, string lastName, string birthday)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
    }


}
