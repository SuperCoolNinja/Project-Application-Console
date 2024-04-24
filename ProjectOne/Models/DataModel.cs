using ProjectOne.Entities;

namespace ProjectOne.Models;

internal class DataModel
{
    public List<Student> Students { get; set; }
    public List<Course> Courses { get; set; }
    public List<Grade> Grades { get; set; }
}
