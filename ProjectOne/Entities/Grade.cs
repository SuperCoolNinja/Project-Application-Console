namespace ProjectOne.Entities;

internal class Grade
{
    public int CourseId { get; set; }
    public double Note { get; set; }
    public string Commentary { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Grade"/> class.
    /// </summary>
    /// <param name="courseId">The ID of the course.</param>
    /// <param name="note">The note for the course.</param>
    /// <param name="commentary">The optional commentary for the grade.</param>
    public Grade(int? courseId, double note, string commentary = "")
    {
        CourseId = courseId ?? -1;
        Note = note;
        Commentary = commentary;
    }
}