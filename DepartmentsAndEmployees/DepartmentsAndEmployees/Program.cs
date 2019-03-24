using System;
using System.Collections.Generic;
using System.Linq;
using DapperDepartments.Data;
using DapperDepartments.Models;

namespace DapperDepartments
{
    class Program
    {
        /// <summary>
        ///  The Main method is the starting point for a .net application.
        /// </summary>
        static void Main(string[] args)
        {
            // We must create an instance of the Repository class in order to use it's methods to
            //  interact with the database.

            Repository repository = new Repository();

            List<Department> departments = repository.GetAllDepartments();

            // PrintDepartmentReport should print a department report to the console, but does it?
            //  Take a look at how it's defined below...

            PrintDepartmentReport("All Departments", departments);

            // What is this? Scroll to the bottom of the file and find out for yourself.

            Pause();


// Create an new instance of a Department, so we can save our new department to the database.

            Department accounting = new Department { DeptName = "Accounting" };

            // Pass the accounting object as an argument to the repository's AddDepartment() method.

            repository.AddDepartment(accounting);

            departments = repository.GetAllDepartments();
            PrintDepartmentReport("All Departments after adding Accounting department", departments);

            Pause();


            // Pull the object that represents the Accounting department from the list of departments that we got from the database.

            Console.WriteLine("First() is a handy LINQ method that gives us the first element in a list that matches the condition");

            Department accountingDepartmentFromDB = departments.First(d => d.DeptName == "Accounting");

            Console.WriteLine("How are the 'accounting' and 'accountingDepartmentFromDB' objects different? and why");
            
            Console.WriteLine($"                accounting --> {accounting.Id}: {accounting.DeptName}");
            Console.WriteLine($"accountingDepartmentFromDB --> {accountingDepartmentFromDB.Id}: {accountingDepartmentFromDB.DeptName}");

            Pause();


// Change the name of the Accounting department and save the change to the database.

            accountingDepartmentFromDB.DeptName = "Creative Accounting";

            repository.UpdateDepartment(accountingDepartmentFromDB.Id, accountingDepartmentFromDB);

            departments = repository.GetAllDepartments();
            PrintDepartmentReport("All Departments after updating Accounting department", departments);

            Pause();


// Maybe we don't need an Accounting department after all...

            repository.DeleteDepartment(accountingDepartmentFromDB.Id);

            departments = repository.GetAllDepartments();
            PrintDepartmentReport("All Departments after deleting Accounting department", departments);

            Pause();


// Create a new variable to contain a list of Employees and get that list from the database
            List<Employee> employees = repository.GetAllEmployees();

            // Does this method do what it claims to do, or does it need some work?
            PrintEmployeeReport("All Employees", employees);

            Pause();


            employees = repository.GetAllEmployeesWithDepartment();
            PrintAllEmployeesWithDepartments("All Employees With Departments", employees);            

            Pause();


            // Here we get the first department by index

            Console.WriteLine("We could use First() here without passing it a condition, but using a [0] index");
            Department firstDepartment = departments[0];

            employees = repository.GetAllEmployeesWithDepartmentByDepartmentId(firstDepartment.Id);

            PrintAllEmployeesWithDepartments($"Employees in {firstDepartment.DeptName}", employees);

            Pause();


// Instantiate a new employee object.
//  Note we are making the employee's DepartmentId refer to an existing department.
//  This is important because if we use an invalid department id, we won't be able to save
//  the new employee record to the database because of a foreign key constraint violation.
            Employee jane = new Employee
            {
                FirstName = "Jane",
                LastName = "Lucas",
                DepartmentId = firstDepartment.Id
            };
            repository.AddEmployee(jane);

            employees = repository.GetAllEmployeesWithDepartment();

            PrintAllEmployeesWithDepartments("All Employees after adding Jane", employees);

            Pause();


            // Once again, we see First() in action.
            Console.WriteLine("Employee dbJane = employees.First(e => e.FirstName == 'Jane')");
             Employee dbJane = employees.First(e => e.FirstName == "Jane");


        /*   // Get the second department by index.
            Console.WriteLine("Department secondDepartment = departments[1];");
            Department secondDepartment = departments[1];
            Console.WriteLine(secondDepartment);
            Pause();

            Console.WriteLine("dbJane.DepartmentId = secondDepartment.Id;");
            dbJane.DepartmentId = secondDepartment.Id;
            Console.WriteLine(secondDepartment.Id);
            Pause();

            Console.WriteLine("repository.UpdateEmployee(dbJane.Id, dbJane)");
            repository.UpdateEmployee(dbJane.Id, dbJane);
            Console.WriteLine(dbJane);
            Pause();

            employees = repository.GetAllEmployeesWithDepartment();
            Pause();

            PrintAllEmployeesWithDepartments("All Employees after updating Jane", employees);

            Pause(); */

            repository.DeleteEmployee(dbJane.Id);
            
            employees = repository.GetAllEmployeesWithDepartment();

            PrintAllEmployeesWithDepartments("All Employees after deleting Jane", employees);

            Pause();
            Pause();

        }



//  Prints a simple report with the given title and department information.
//  Each line of the report should include the Department's ID and Name

// <param name="title">Title for the report</param>
// <param name="departments">Department data for the report</param>
/* TODO: Complete this method - For example a report entitled, "All Departments" should look like this:
                All Departments
                1: Marketing
                2: Engineering
                3: Design */

        public static void PrintDepartmentReport(string title, List<Department> departments)
        {
            Console.WriteLine(title);

            foreach (Department taco in departments)
            {
                string DeptName = taco.DeptName;
                int Id = taco.Id;
                Console.WriteLine($"{Id}: {DeptName}");
            }
        }


//  Prints a simple report with the given title and employee information
/* All Employees
                1: Margorie Klingerman
                2: Sebastian Lefebvre
                3: Jamal Ross */

// Each line of the report should include the Employee's ID, First Name, Last Name, and department name 
// IF AND ONLY IF the department is not null.

// <param name="title">Title for the report</param>
// <param name="employees">Employee data for the report</param>

        public static void PrintEmployeeReport(string title, List<Employee> employees)
        {
            Console.WriteLine(title);

            foreach (Employee taco in employees)
            {
                string FirstName = taco.FirstName;
                string LastName = taco.LastName;
                int Id = taco.Id;
                Console.WriteLine($"{Id}: {FirstName} {LastName}");
            }
        }

/*  A report entitled, "All Employees with Departments", should look like this:

    All Employees with Departments
    1: Margorie Klingerman. Dept: Marketing
    2: Sebastian Lefebvre. Dept: Engineering
    3: Jamal Ross. Dept: Design */

        public static void PrintAllEmployeesWithDepartments(string title, List<Employee> employees)
        {
            Console.WriteLine(title);

            foreach (Employee taco in employees)
            {
                if (taco.Department != null)
                    
                    {
                        string FirstName = taco.FirstName;
                        string LastName = taco.LastName;
                        int Id = taco.Id;
                        Console.WriteLine($"{taco.Id}: {taco.FirstName} {taco.LastName} works in {taco.Department.DeptName}");
                    }
                    else
                    {
                        Console.WriteLine($"{taco.Id}: {taco.FirstName} {taco.LastName}");
                    }
            }
        }



        //  Custom function that pauses execution of the console app until the user presses a key

        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
