using System;
using System.Collections.Generic;

namespace Program
{
    // Create a custom type for Company.
    // A company has the following properties.
    // Date founded (DateTime)
    // Company name (string)
    // Employees (List<Employee>)
    // The Company class should also have a ListEmployees() method
    // which outputs the name of each employee to the console.
    public class Company {
        public string CompanyName {get;}
        public DateTime CreatedOn {get;}
        public List<Employee> CompanyEmployee;
        // A constructor is special method in a class that is called when a new 
        // instance of the class is created. The role of a constructor is 
        // to make sure the new object is setup and ready for use immediately 
        // after it is created. A constructor is not required in a class. If a 
        // class does not have a constructor it will be given a hidden, "default" 
        // constructor that accepts no parameters and does nothing.
        // The constructor sets the values of the public properties

        public Company(string cName, DateTime cCreatedOn) 
        {
        //  attribute = argument - inside constructor
            CompanyName = cName;
            CreatedOn = cCreatedOn;
            CompanyEmployee = new List<Employee>();
        }

         // The Company class should also have a ListEmployees() 
         // method which outputs the name of each employee to the
         // console.
        public void ListEmployees() {

            foreach (Employee worksHere in CompanyEmployee) {
                Console.WriteLine($"{worksHere.FirstName} {worksHere.LastName} has worked at {CompanyName} as a {worksHere.Title} since {worksHere.StartDate}");
            }
        }
    }
}