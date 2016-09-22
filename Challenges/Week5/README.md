# Week 5 Challenge
### Focusing On:
#### SQL Basics, Modifying Data with SQL, and ASP.NET MVC Basics

## The problem:
I want to create a simple MVC application that Creates, Reads, Updates, and Deletes employees for our hr department at FakeCo. 
I've started to work on it but got pulled away to work on another project. 
I would like you to finish it for me. (I guess I'm passing the buck?)

Here's what I've completed:
* The repository methods to talk to the database and perform CRUD operations.
* I've created the default controller and started building some of the methods.
* The index view and method that lists all of our employees.
* The edit view and method.
* The create view.

Here's what I need you to complete for me:
* Finish the create method for creating a new employee.
* Create the view and method for seeing the details of an employee.
* Create the view and methods for deleting an employee. 
* Enable sorting on the index view, so we can easily sort our employees.

Here's what we have left, but not pressing. (a.k.a bonus)
* Install a copy of MySql or Microsoft SQL Express (links provided) on your local computer or server and switch the app over to use a server instead of the localdb file. I have provided SQL scripts for both MySql and MsSql to populate the database with data.
* There are more tables that contain more information about the employee that we aren't using. Join (bring in related data) the employee table with the Department and / or Position table and display that information in the list view.
  * Most of the code is already written, you just have to uncomment it out and finish what I've started.
  * Implement error handling on the methods that interact with the database, so if something fails make sure it's handled gracefully.

## Directions:
Right now we're working from a local database file, so you shouldn't need to download any server software.

1. Bringing down this challenge and open the project. Before doing anything else, try to build (Menu - Build, Build Solution). This will try and restore
any NuGet packages (libraries) that are installed on the project.
2. Open up the DefaultController.cs file in the Controllers folder to get started. If you would like to see the in project TODO list open the task list
by going to Menu - View, Task List. By using the task list, you can jump to any spot in the code by double clicking the task.

## Links:
#### MySql Community Installer (Make sure to install the server and management software)
https://dev.mysql.com/downloads/mysql/5.6.html

#### Microsoft SQL Server Express (Make sure to install the server and management software)
https://www.microsoft.com/en-us/download/details.aspx?id=52679

#### Stack Overflow Documentation
http://stackoverflow.com/tour/documentation

#### My Slack Username - @steven.heigl
If you have any problems compiling or get stuck, just ask me!
