using System;
using System.Collections.Generic;

namespace StudentExercises
{
  public class Student
  {
     public string StudentFirstName {get; set;}
     public string StudentLastName {get; set;}
     public string StudentSlackHandle {get; set;}
     public string CohortName {get; set;}
     public List<Exercise> Exercises;

     // Constructor for adding
     public Student(string fName, string lName, string sHandle, string sCohort)
     {
         StudentFirstName = fName;
         StudentLastName = lName;
         StudentSlackHandle = sHandle;
         CohortName = sCohort;
         Exercises = new List<Exercise>();
     }
  }  
}