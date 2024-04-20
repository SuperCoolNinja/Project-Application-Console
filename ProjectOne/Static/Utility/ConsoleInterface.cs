using ProjectOne.Entities;

namespace ProjectOne.Static.Utility;


/// <summary>
/// Input and output data to users using the default Console.
/// </summary>
internal static class ConsoleInterface
{

    /// <summary>
    /// Prompts the user to input a numerical choice.
    /// </summary>
    /// <returns>The user input choice as an integer.</returns>
    public static int AskUserOption()
    {
        Console.Write("Choose an option: ");

        int input = -1;
        while (!int.TryParse(Console.ReadLine(), out input))
            Console.Write("Choose an option: ");

        return input;
    }


    /// <summary>
    /// Output the main menu.
    /// </summary>
    public static void ShowMainMenu(string title, List<string> options)
    {
        Console.WriteLine($"{title} :");

        for (int i = 0; i < options.Count; i++)
            Console.WriteLine($"{i + 1} - {options[i]}");
    }


    /// <summary>
    /// Output a list of students.
    /// </summary>
    /// <param name="students">list of student.</param>
    public static void ShowStudentList(List<Student> students)
    {
        Console.Clear();

        Console.WriteLine($"List of student :\n");
        
        foreach (Student student in students)
            Console.WriteLine($"\tId : {student.Id}\n\tName : {student.FirstName} {student.LastName}\n\tBirthday : {student.Birthday}\n\n");
    }
}
