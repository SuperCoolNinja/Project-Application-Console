# Project-Application-Console
Wild Code School, First Project - C# .NET Application Console.

# Application Overview
    Student Management:
        List Students: Display a list of all students in the system.
        Create New Student: Add new students to the system, capturing essential details like name, date of birth, and unique identifier.
        View Student Details: Access detailed profiles of existing students, including their courses, grades, and teacher comments.
        Add Grades and Comments: Enter or update grades and optional teacher comments for specific courses for any student.

    Course Management:
        List Courses: Show all the courses available within the educational program.
        Add New Course: Introduce new courses into the system with unique identifiers and names.
        Delete Course: Remove existing courses from the system, along with any associated grades and comments in student profiles to ensure data consistency.

    Grade Entry and Review:
        Grade Input: Teachers can input grades for students for specific courses, with a straightforward option to add comments.
        Grade Confirmation: The system will provide a summary of the grade and comments before finalizing the entry to prevent errors.

    Data Handling and Security:
        Local Data Storage: All data is saved locally in a JSON file format, allowing easy transfer via removable media like USB drives and ensuring data security against online breaches.
        Dynamic Calculations: Automatically calculate students' average grades based on entered data, which is displayed but not stored to keep the data file simple.

    Logging:
        Action Logging: Every significant action taken by users, such as data modifications or views, is logged with timestamps for accountability and tracking purposes.

Technology Stack

* Language and Framework: The application will be developed in C# using .NET Core 7.0.
* Dependencies: Nuget packages can be used for external dependencies.
* Data Handling: Data persistence will be implemented in a simple JSON text file format using the Newtonsoft.JSON library.
* Development Environment: Development and compilation will be carried out using Visual Studio Code.

