﻿using ProjectOne.Entities;
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
     
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
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
        string? birthday = null;
        bool isRegisterDone = false;

        do
        {
            Console.WriteLine("\n\nEnter student details: [type exit to cancel]");
            Console.Write("Firstname: ");
            firstName = Console.ReadLine();

            if (firstName == "exit")
                break;

            if (InputValidator.AnyNullOrEmpty(firstName))
                Console.WriteLine("Firstname cannot be empty.");
            else if (InputValidator.ContainsDigits(firstName))
                Console.WriteLine("Firstname should not contain digits.");
            else
            {
                Console.Write("Lastname: ");
                lastName = Console.ReadLine();
                if (lastName == "exit")
                    break;


                if (InputValidator.AnyNullOrEmpty(lastName))
                    Console.WriteLine("Lastname cannot be empty.");
                else if (InputValidator.ContainsDigits(lastName))
                    Console.WriteLine("Lastname should not contain digits.");
                else
                {
                    Console.Write("Birthday (Format: DD/MM/YYYY): ");
                    birthday = Console.ReadLine();
                    if (birthday == "exit")
                        break;

                    if (!InputValidator.IsValidDate(birthday))
                        Console.WriteLine("Birthday must be in the correct format (DD/MM/YYYY) and a valid date.");
                    else isRegisterDone = true;
                }
            }
        } while (!isRegisterDone);

        Console.Clear();

        return (firstName, lastName, birthday);
    }

    /// <summary>
    /// Prompts the user to input a numerical choice.
    /// </summary>
    /// <returns>The user input choice as an integer.</returns>
    public static int AskUserID()
    {
        Console.WriteLine("Student List:");
        foreach (var student in ApplicationManager.Students)
            Console.WriteLine($"ID: {student.Id}, Name: {student.FirstName} {student.LastName}");

        int id;
        while (true)
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out id))
            {
                // Check if the entered ID exists
                if (ApplicationManager.Students.Any(student => student.Id == id))
                    break;
                else Console.WriteLine("Invalid student ID. Please enter a valid student ID.");
            }
            else Console.WriteLine("Invalid input. Please enter a valid student ID.");
        }

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


        if (student.GradesList.Count > 0)
        {
            Console.WriteLine("\tGrades:");

            double noteAverage = 0;
            foreach (var grade in student.GradesList)
            {
                string comment = grade.Commentary.Length > 0 ? "Commentary : " + grade.Commentary : "";
                var courseName = ApplicationManager.Courses.Find(c => c.Id == grade.CourseId)?.Name;

                noteAverage += grade.Note;

                Console.WriteLine($"\t\tCourse: {courseName ?? "Unknown"}, \n\t\t\tNote : {grade.Note}/20, \n\t\t\t{comment}");

                Console.WriteLine();
            }

            noteAverage /= student.GradesList.Count;

            Console.WriteLine($"\t\tAverage : {noteAverage}/20");
        }
    }

    /// <summary>
    /// Prompts the user to enter the ID of a course.
    /// </summary>
    /// <returns>The ID of the course entered by the user.</returns>
    public static int? AskCourseID()
    {
        Console.WriteLine("Course List (Type exit to cancel.)");
        foreach (var course in ApplicationManager.Courses)
            Console.WriteLine($"ID: {course.Id}, Name: {course.Name}");

        int id;
        while (true)
        {
            Console.Write("Enter course ID: ");
            var courseId = Console.ReadLine();

            if (courseId.ToLower() == "exit")
                return null;

            if (int.TryParse(courseId, out id))
            {
                // Check if the entered ID exists
                if (ApplicationManager.Courses.Any(course => course.Id == id))
                    break;
                else Console.WriteLine("Invalid course ID. Please enter a valid course ID.");
            }
            else Console.WriteLine("Invalid input. Please enter a valid course ID.");
        }

        return id;
    }

    /// <summary>
    /// Prompts the user to enter confirmation.
    /// </summary>
    /// <returns>Return True if the user type Yes or y else no.</returns>
    public static bool DoesUserConfirm()
    {
        string? userInput = null;

        Console.WriteLine("Are you sure ?");

        do
        {
            Console.Write("Enter Yes or No : ");
            userInput = Console.ReadLine();
        } while (InputValidator.AnyNullOrEmpty(userInput));

        if (userInput.ToLower() == "y" || userInput.ToLower() == "yes")
            return true;

        Console.WriteLine("Operation canceled.");

        return false;
    }

    /// <summary>
    /// Prompts the user to enter a note out of 20.
    /// </summary>
    /// <returns>The note entered by the user, which should be between 0 and 20.</returns>
    public static int AskNote()
    {
        Console.Write("Enter note (out of 20): ");
        int note;
        while (!int.TryParse(Console.ReadLine(), out note) || note < 0 || note > 20)
            Console.Write("Invalid note. Enter note (out of 20): ");

        return note;
    }

    /// <summary>
    /// Prompts the user to enter a commentary (optional).
    /// </summary>
    /// <returns>The commentary entered by the user.</returns>
    public static string AskCommentary()
    {
        Console.Write("Enter commentary (optional): ");
        return Console.ReadLine();
    }



    public static void ShowAllCourses()
    {
        Console.WriteLine("Course List : \n");
        foreach (var course in ApplicationManager.Courses)
        {
            var courseName = course.Name[0].ToString().ToUpper() + course.Name.Substring(1);
            Console.WriteLine($"\tID: {course.Id}, Name: {courseName}");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }

    public static string? AskCourseInfo()
    {
        string? name;
        do
        {
            Console.WriteLine("\n\nEnter course details: [type exit to cancel]");
            Console.Write("Name: ");
            name = Console.ReadLine();

            if (name == "exit")
                break;


            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("name cannot be empty.");
            }
            else
            {
                name = name?.ToLower();

                if (ApplicationManager.Courses.Any(v => v.Name.ToLower() == name))
                    Console.WriteLine("This course already exist.");
            }
        } while (string.IsNullOrWhiteSpace(name) || ApplicationManager.Courses.Any(v => v.Name.ToLower() == name));

        Console.Clear();

        return name;
    }

    internal static void Clear()
    {
        Console.Clear();
    }
}
