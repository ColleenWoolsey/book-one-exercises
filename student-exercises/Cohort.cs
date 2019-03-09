using System;
using System.Collections.Generic;

namespace StudentExercises
{
  public class Cohort
  {
     public string CohortName {get; set;}
     public List<Student> Students;
     public List<Instructor> Instructors;

     // Constructor for adding
     public Cohort(string cName) {
         CohortName =cName;
         Students = new List<Student>();
         Instructors = new List<Instructor>();
     }

     // Method that lists students in that cohort
    public void ListStudents() {
        foreach (Student item in Students) {
            Console.WriteLine($"{item.CohortName} Student: {item.StudentFirstName} {item.StudentLastName}");
        }
    }

     // Method that lists Instructors in that cohort
     public void ListInstructors() {
        foreach (Instructor item in Instructors) {
            Console.WriteLine($"{item.CohortName} Instructor: {item.InstructorFirstName} {item.InstructorLastName}");
        }     
    }
  }  
}