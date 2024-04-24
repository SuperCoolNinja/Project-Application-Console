namespace ProjectOne.Entities;

internal class Course
{
    public int Id { get; private set; }
    public string Name { get; set; }

    private static int _nextId = 1;

    public Course(string name)
    {
        Id = _nextId++;
        Name = name;
    }
}