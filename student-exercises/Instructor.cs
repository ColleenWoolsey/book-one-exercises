using System;
using System.Collections.Generic;

namespace StudentExercises
{
  public class Instructor
  {
     public string InstructorFirstName {get; set;}
     public string InstructorLastName {get; set;}
     public string InstructorSlackHandle {get; set;}
     public string CohortName {get; set;}
     public List<Student> InstructorsStudentList {get; set;}
     public List<Exercise> InstructorsExerciseList {get; set;}

     public Instructor(string fName, string lName, string sHandle, string cName) {
         InstructorFirstName = fName;
         InstructorLastName = lName;
         InstructorSlackHandle = sHandle;
         CohortName = cName;
         InstructorsStudentList = new List<Student>();
         InstructorsExerciseList = new List<Exercise>();
     }

     public void AssignExercise(Exercise exercise, Student student) {
            student.TheStudentsExerciseList.Add(exercise);
        
     }
  }  
}