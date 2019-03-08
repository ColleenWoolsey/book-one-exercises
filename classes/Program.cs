using System;
using System.Collections.Generic;

namespace Program
{

  class Program
  {
// A static attribute on the class is shared by all the 
// objects in all of the instances of that class
    static void Main(string[] args)
    {
        // Create an instance of a company. Name it whatever you like.
        // We call a constructor when we use the new keyword.
        Company myCompany = new Company("My Company", new DateTime(2019, 03, 07));        

        // Create three employee objects with constructor 
        Employee employee1 = new Employee 
            ("Tom", "One", "Grand Pooba", new DateTime(2019, 03, 07));
            Console.WriteLine($"FYI - This associates a value with the actual employee in program constructor - Value: {employee1.getEmployeeCount()}");
        Employee employee2 = new Employee
            ("Dick", "Two", "Pooba", new DateTime(2018, 03, 07));
            Console.WriteLine(value: employee2.getEmployeeCount());
        Employee employee3 = new Employee
            ("Harry", "Three", "Wannabe", new DateTime(2017, 03, 07));
            Console.WriteLine(value: employee3.getEmployeeCount());

        // Employee employee1 = new Employee()
        // {
        // employee1.FirstName = "Tom";
        // employee1.LastName = "One";
        // employee1.Title = "Grand Pooba";
        // employee1.StartDate = new DateTime(2019, 03, 07)
        // };
        

        // Assign the employees to the company
        myCompany.CompanyEmployee.Add(employee1);
        myCompany.CompanyEmployee.Add(employee2);
        myCompany.CompanyEmployee.Add(employee3);

        
        // Iterate the company's employee list and generate the
        // simple report shown above
        myCompany.ListEmployees();
    }
 }
    
}
