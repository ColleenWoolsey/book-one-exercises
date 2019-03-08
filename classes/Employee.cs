using System;

namespace Program
{
    // Create a public property for holding a list of current employees
    // Create a custom type for Employee. An employee has the following properties.
    // First name (string)
    // Last name (string)
    // Title (string)
    // Start date (DateTime)

    public class Employee
    {
        // Class PROPERTIES are the interface you provide to external code to get, 
        // and modify, the values of the private fields.
        public string FirstName {get; set;}
        // If I wanted to set the property globaly I would say:
        // public string FirstName {get; set;} = "John"
        public string LastName {get; set;}
        public string Title {get; set;}
        public DateTime StartDate {get; set;}
        // A static attribute on the class is shared by all the 
        // objects - not unique to the object like the firstName
        // Console.WriteLine(Employee.numberOfEmployees);

        // METHODS
        public static int numberOfEmployees = 0;

        // Calculated property that has no setter. It is readonly.
        public string FullName {get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public Employee(string fName, string lName, string eTitle, DateTime eStart) 
        {
        //  attribute = argument - inside constructor
            FirstName = fName;
            LastName = lName;
            Title = eTitle;
            StartDate = eStart;
            numberOfEmployees++;
            Console.WriteLine($"This is the number of employees added inside the constructor function in Employee: {Employee.numberOfEmployees}");
            Console.WriteLine($"{FirstName} {LastName}, {Title}, started on {StartDate}");
        }

        public int getEmployeeCount() {
            return numberOfEmployees;
        }
    }
}