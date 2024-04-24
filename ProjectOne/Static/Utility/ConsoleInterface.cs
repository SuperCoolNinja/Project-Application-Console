using ProjectOne.Entities;
using ProjectOne.Static.Manager;
using System.Diagnostics;

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

        Console.Clear();

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
    public static void ShowAllStudent()
    {
        Console.WriteLine("List of Students:");
        foreach (var student in ApplicationManager.Students)
        {
            Console.WriteLine($"\n\tStudent:\n " +
                $"\t\tID : {student.Id}\n" +
                $"\t\tName : {student.FirstName} {student.LastName}\n" +
                $"\t\tBirthday : {student.Birthday}");
        }
    }


    /// <summary>
    /// Asks for student info and returns it as a tuple.
    /// </summary>
    /// <returns>
    /// A tuple containing three strings:
    /// - firstname: The student's first name.
    /// - lastname: The student's last name.
    /// - birthday: The student's birthday in the format "MM/DD/YYYY".
    /// </returns>
    public static (string? firstname, string? lastname, string? birthday) AskStudentInfo()
    {
        string? firstName = null;
        string? lastName = null;
        string? birthday = null; ;
        bool isAnyFieldEmpty, doNamesContainDigits, isBirthdayInvalid;

        do
        {
            Console.WriteLine("\n\nEnter student details: [type exit to cancel]");
            Console.Write("Firstname: ");
            firstName = Console.ReadLine();

            if (firstName == "exit")
                break;

            Console.Write("Lastname: ");
            lastName = Console.ReadLine();
            if (lastName == "exit")
                break;


            Console.Write("Birthday (Format: DD/MM/YYYY): ");
            birthday = Console.ReadLine();
            if (birthday == "exit")
                break;

            isAnyFieldEmpty = InputValidator.AnyNullOrEmpty(firstName, lastName, birthday);
            doNamesContainDigits = InputValidator.ContainsDigits(firstName, lastName);
            isBirthdayInvalid = !InputValidator.IsValidDate(birthday);



            if (isAnyFieldEmpty)
                Console.WriteLine("No fields can be empty.");

            if (doNamesContainDigits)
                Console.WriteLine("Names should not contain digits.");

            if (isBirthdayInvalid)
                Console.WriteLine("Birthday must be in the correct format (DD/MM/YYYY) and a valid date.");

        } while (isAnyFieldEmpty || doNamesContainDigits || isBirthdayInvalid);

        Console.Clear();

        return (firstName, lastName, birthday);
    }

    /// <summary>
    /// Prompts the user to input a numerical choice.
    /// </summary>
    /// <returns>The user input choice as an integer.</returns>
    public static int AskUserID()
    {
        Console.Write("Enter student id : ");

        int id;

        while (!int.TryParse(Console.ReadLine(), out id))
            Console.Write("id : ");

        Console.Clear();

        return id;
    }

    /// <summary>
    /// Output the student data.
    /// </summary>
    /// <param name="student">The Student to show.</param>
    public static void ShowUserData(Student student)
    {
        Console.WriteLine($"\n\tStudent:\n " +
            $"\t\tID : {student.Id}\n" +
            $"\t\tFirstname : {student.FirstName}\n" +
            $"\t\tLastname : {student.LastName}\n" +
            $"\t\tBirthday : {student.Birthday}");

        Console.WriteLine("\tGrades:");


        foreach (var grade in student.GradesList)
        {
            string comment = grade.Commentary.Length > 0 ? "Commentary : " + grade.Commentary : "";
            var courseName = ApplicationManager.Courses.Find(c => c.Id == grade.CourseId)?.Name;

            Console.WriteLine($"\t\tCourse: {courseName ?? "Unknown"}, \n\t\t\tNote : {grade.Note}/20, \n\t\t\t{comment}");

            Console.WriteLine();
        }
    }

}
