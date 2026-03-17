using System;
using System.Collections.Generic;
using System.Linq;

// ---------------- BASE CLASS ----------------
class Employee
{
    public int Id;
    public string Name;
    public string Department;
    public double BaseSalary;

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }

    public virtual string GetEmployeeType()
    {
        return "Employee";
    }
}

// ---------------- FULL-TIME EMPLOYEE ----------------
class FullTimeEmployee : Employee
{
    public double Bonus;

    public override double CalculateSalary()
    {
        return BaseSalary + Bonus;
    }

    public override string GetEmployeeType()
    {
        return "Full-Time";
    }
}

// ---------------- CONTRACT EMPLOYEE ----------------
class ContractEmployee : Employee
{
    public int HoursWorked;
    public double HourlyRate;

    public override double CalculateSalary()
    {
        return HoursWorked * HourlyRate;
    }

    public override string GetEmployeeType()
    {
        return "Contract";
    }
}

// ---------------- MAIN PROGRAM ----------------
class Program
{
    static List<Employee> employees = new List<Employee>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Employee Management System ---");
            Console.WriteLine("1. Add Full-Time Employee");
            Console.WriteLine("2. Add Contract Employee");
            Console.WriteLine("3. View All Employees");
            Console.WriteLine("4. Search by Department");
            Console.WriteLine("5. Sort by Salary");
            Console.WriteLine("6. Delete Employee");
            Console.WriteLine("7. Show Highest Paid Employee");
            Console.WriteLine("8. Show Average Salary");
            Console.WriteLine("9. Group by Department");
            Console.WriteLine("10. Exit");
            Console.Write("Enter choice: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddFullTime(); break;
                    case 2: AddContract(); break;
                    case 3: ViewAll(); break;
                    case 4: Search(); break;
                    case 5: SortBySalary(); break;
                    case 6: DeleteEmployee(); break;
                    case 7: HighestPaid(); break;
                    case 8: AverageSalary(); break;
                    case 9: GroupByDepartment(); break;
                    case 10: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
            catch
            {
                Console.WriteLine("Enter valid numeric input!");
            }
        }
    }

    // --------- Add Full-time ----------
    static void AddFullTime()
    {
        FullTimeEmployee f = new FullTimeEmployee();
        try
        {
            Console.Write("Id: "); f.Id = int.Parse(Console.ReadLine());
            Console.Write("Name: "); f.Name = Console.ReadLine();
            Console.Write("Department: "); f.Department = Console.ReadLine();
            Console.Write("Base Salary: "); f.BaseSalary = double.Parse(Console.ReadLine());
            Console.Write("Bonus: "); f.Bonus = double.Parse(Console.ReadLine());

            employees.Add(f);
            Console.WriteLine("Full-Time Employee Added!");
        }
        catch { Console.WriteLine("Invalid input!"); }
    }

    // --------- Add Contract ----------
    static void AddContract()
    {
        ContractEmployee c = new ContractEmployee();
        try
        {
            Console.Write("Id: "); c.Id = int.Parse(Console.ReadLine());
            Console.Write("Name: "); c.Name = Console.ReadLine();
            Console.Write("Department: "); c.Department = Console.ReadLine();
            Console.Write("Hours Worked: "); c.HoursWorked = int.Parse(Console.ReadLine());
            Console.Write("Hourly Rate: "); c.HourlyRate = double.Parse(Console.ReadLine());

            employees.Add(c);
            Console.WriteLine("Contract Employee Added!");
        }
        catch { Console.WriteLine("Invalid input!"); }
    }

    // --------- View All ----------
    static void ViewAll()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        foreach (var e in employees)
        {
            Console.WriteLine($"\nID: {e.Id}, Name: {e.Name}, Dept: {e.Department}, " +
                              $"Type: {e.GetEmployeeType()}, Salary: {e.CalculateSalary()}");
        }
    }

    // --------- Search ----------
    static void Search()
    {
        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        var result = employees.Where(e => e.Department.Equals(dept, StringComparison.OrdinalIgnoreCase));

        if (!result.Any())
        {
            Console.WriteLine("No employee found.");
            return;
        }

        foreach (var e in result)
            Console.WriteLine($"{e.Name} - {e.CalculateSalary()}");
    }

    // --------- Sort ----------
    static void SortBySalary()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees to sort.");
            return;
        }

        var sorted = employees.OrderByDescending(e => e.CalculateSalary());

        foreach (var e in sorted)
            Console.WriteLine($"{e.Name} - {e.CalculateSalary()}");
    }

    // --------- Delete ----------
    static void DeleteEmployee()
    {
        Console.Write("Enter Employee Id: ");
        int id = int.Parse(Console.ReadLine());

        var emp = employees.FirstOrDefault(e => e.Id == id);

        if (emp == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        employees.Remove(emp);
        Console.WriteLine("Employee Deleted.");
    }

    // --------- Highest Paid ----------
    static void HighestPaid()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("Empty list.");
            return;
        }

        var high = employees.OrderByDescending(e => e.CalculateSalary()).First();
        Console.WriteLine($"Highest Paid: {high.Name} - {high.CalculateSalary()}");
    }

    // --------- Average Salary ----------
    static void AverageSalary()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees.");
            return;
        }

        Console.WriteLine("Average Salary: " + employees.Average(e => e.CalculateSalary()));
    }

    // --------- Group by Department ----------
    static void GroupByDepartment()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees.");
            return;
        }

        var groups = employees.GroupBy(e => e.Department);

        foreach (var g in groups)
        {
            Console.WriteLine($"\nDepartment: {g.Key}");
            foreach (var e in g)
                Console.WriteLine($"  {e.Name} - {e.GetEmployeeType()}");
        }
    }
}