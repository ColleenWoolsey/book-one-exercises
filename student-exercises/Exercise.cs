using System;
using System.Collections.Generic;

namespace StudentExercises
{
  public class Exercise
  {
     public string ExerciseName {get; set;}
     public string Language {get; set;}

     public Exercise(string eName, string eLanguage) {
         ExerciseName = eName;
         Language = eLanguage;
     }
  }  
}