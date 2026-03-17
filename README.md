Employee Management System is a C# Console Application built using OOP concepts, Inheritance, Polymorphism, Collections, and Exception Handling.
It manages both Full-Time and Contract employees inside a single list using a menu‑based interface.
Key Features

Uses OOP + Inheritance with a base Employee class and two derived classes:

FullTimeEmployee (BaseSalary + Bonus)
ContractEmployee (HoursWorked × HourlyRate)


Stores all employees in a List.
Menu operations include:

Add Full-Time / Contract Employee
View All Employees
Search by Department
Sort by Salary
Delete Employee
Show Highest Paid Employee
Show Average Salary
Group by Department


Implements virtual/override methods for salary calculation.
Includes input validation and basic exception handling.





This Employee Management System is a C# Console Application built using **OOP, Inheritance, Polymorphism, Collections, and ADO.NET (SQL Database)**.  
It allows you to manage both **Full-Time** and **Contract** employees and also fetch employee records directly from a SQL Server table.

Key Features : 

*   Base class `Employee` with derived classes `FullTimeEmployee` and `ContractEmployee`
*   Salary calculation using **virtual/override**
*   Operations included:
    *   Add Employee
    *   View All Employees
    *   Search by Department
    *   Sort by Salary
    *   Delete Employee
    *   Bonus features: Highest Salary, Average Salary, Group by Department
*   SQL Database Integration
    *   Fetches employees from SQL table `EmployeesDB`
    *   Displays results in the console
*   Uses **List<Employee>** to store all employee types
*   Input validation with simple error handling

Database Support :

The application connects to SQL Server using a connection string and retrieves employee data using ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`).



