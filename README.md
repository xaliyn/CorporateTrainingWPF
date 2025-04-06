#  Corporate Training Management System (WPF Project)

This is a beginner-friendly desktop application we built using *WPF (.NET)* and *Entity Framework Core* for my Visual Programming course.

The goal was to create a *CRUD app* (Create, Read, Update, Delete) that helps manage:
- Instructors
- Participants
- Trainings

##  Technologies we Learned & Used

- *WPF (Windows Presentation Foundation)* for building the UI
- *Entity Framework Core* for connecting to the database
- *SQL Server Express* as the database manager
- *MVVM-lite logic* and simple navigation
- Basic data validation in C#

##  Features

-  Add, edit, delete *Instructors*
-  Add, edit, delete *Participants*
-  Create *Trainings*, assign to *one Instructor*
-  Manage *many-to-many* relationship between Trainings and Participants
-  Clean WPF UI with basic error checking
-  SQL Server integration using EF Core

##  How to Run It

1. Clone this repo  
2. Open the solution in Visual Studio 2022
3. Open *Package Manager Console* and run
4. Press *F5* to run the app

Make sure SQL Server Express is installed on your machine!

##  Demo Walkthrough

- The *Main Menu* lets you choose what to manage
- Every screen allows adding, editing, and deleting
- Data is saved in a local SQL Server database
- Code-first approach with EF Core

##  What we Learned

This project helped us understand:
- How WPF and XAML work
- What databases and relationships are
- How to connect frontend to backend using Entity Framework
- How to use GitHub and write beginner-friendly code


**Thank you!**