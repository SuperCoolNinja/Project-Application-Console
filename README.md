# Project-Application-Console
Wild Code School, First Project - C# .NET Application Console.

# Quick description : 
This First project has been made to learn OOP and Data persistance with text file using JSON.

# Here is the requirement needed to be valide : 
Project Validation Requirements Summary:

Functional Specification

    The application operates based on functional requirements defined.
    Data is structured according to JSON format.

Data File

    Utilizes a JSON data file passed as an argument during program launch.
    Must have write access and can reside on any accessible storage.

Menu

    Application launches with a menu for user interaction.
    Menu options include "Students" and "Courses."

Student Menu

    Provides options to:
        List students
        Create a new student
        View existing student details
        Add a grade and teacher's feedback for a course
        Return to the main menu

Course Menu

    Provides options to:
        List existing courses
        Add a new course to the program
        Delete a course by its identifier
        Return to the main menu

Student Entity

    Attributes include:
        Unique numeric identifier
        Textual first and last names
        Date of birth
        List of grades (decimal numbers) and teacher's feedback (text) for each course
        Average grade calculated dynamically (not stored in the file)

Course Entity

    Attributes include:
        Unique numeric identifier
        Textual name

Course Deletion

    Deleting a course removes associated grades and feedback for all students.
    Requires confirmation to prevent accidental deletion.

Adding Grade and Feedback

    User must specify the course for input.
    Teacher's feedback is optional; only the grade is mandatory.
    Summary and confirmation prompt before adding input to the student.

Data Storage

    User modifications trigger JSON file updates.
    Program initializes existing data from the JSON file at launch.

Average Calculation

    Average grade is dynamically calculated.
    Rounded to one decimal place (e.g., 12.3 => 12.5/20).

Display

    Data presentation ensures clarity and readability.
    Sample format provided for student information.

Error Handling

    User inputs are validated to prevent errors.
    Invalid inputs prompt re-entry with appropriate instructions.

Log File

    Records all user actions, including data modifications and consultations.
    Log file shares the name and location of the JSON file with a different extension.
    Timestamped entries for clear interpretation.
