using System;
using System.Collections.Generic;

namespace StudentExercises
{
  public class Cohort
  {
     public string CohortName {get; set;}
     public List<Student> CohortStudentList {get; set;}
     public List<Instructor> CohortInstructorList {get; set;}

     // Constructor for adding
     public Cohort(string cName) {
         CohortName =cName;
         CohortStudentList = new List<Student>();
         CohortInstructorList = new List<Instructor>();
     }

     // Method that lists students in that cohort
    public void ListStudents() {
        foreach (Student item in CohortStudentList) {
            Console.WriteLine($"     Student: {item.StudentFirstName} {item.StudentLastName}");
        }
    }

     // Method that lists Instructors in that cohort
     public void ListInstructors() {
        foreach (Instructor item in CohortInstructorList) {
            Console.WriteLine($"** Instructor: {item.InstructorFirstName} {item.InstructorLastName}");
        }     
    }
  }  
}