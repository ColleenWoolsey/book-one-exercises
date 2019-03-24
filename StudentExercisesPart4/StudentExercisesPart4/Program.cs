
using System;
using System.Collections.Generic;
using StudentExercisesPart4.Data;
using StudentExercisesPart4.Models;


/* programs is for startup - kind of like index.js and written by Visual Studio */

namespace StudentExercisesPart4
{
    class Program
    {
        static void Main(string[] args)
        {
            // We must create an instance of the Repository class in order to use it's methods to
            //  interact with the database.

            Repository repository = new Repository();

            // ********** Place where 1. calling functions in repository and 2. defining methods? **********

// 1. Query the database for all the Exercises.
            List<Exercise> exercises = repository.GetAllExercises();
            PrintExerciseReport("All Exercises", exercises);
            Pause();

// 2. Find all the exercises in the database where the language is JavaScript.
            List<Exercise> jExercises = repository.GetAllJavaScriptExercises("JavaScript");
            PrintExerciseReport("Only JavaScript Exercises", jExercises);
            Pause();

// 3. Insert a new exercise into the Exercise table
            Exercise nutshell = new Exercise()
            {
                ExerciseName = "Nutshell",
                Language = "React"
            };
            repository.AddExercise(nutshell);
            exercises = repository.GetAllExercises();
            PrintExerciseReport("All Exercises after adding one", exercises);
            Pause();

// 4. Find all instructors in the database. Include each instructor's cohort
//    Seems easier to print to Console than create a unique report for each query like PrintExerciseReport?? So ...

            List<Instructor> instructors = repository.GetAllInstructorsWithCohort();
            Console.WriteLine("All Instructors With Cohort");
            foreach (Instructor i in instructors)
            {
                Console.WriteLine($"{i.InstructorFirstName} {i.InstructorLastName} is in {i.Cohort.CohortName}");
            }
            Pause();

//Insert a new instructor into the database. Assign the instructor to an existing cohort 
            Instructor joeShmoe = new Instructor()
            {
                InstructorFirstName = "Joe",
                InstructorLastName = "Shmoe",
                InstructorSlackHandle = "JoeShmoe@Nss",
                CohortId = 3
            };
            repository.AddInstructor(joeShmoe);

            // List<Instructor> instructors = repository.GetAllInstructorsWithCohort();
            Console.WriteLine("All Instructors With Cohort after adding one");
            foreach (Instructor i in repository.GetAllInstructorsWithCohort())
            {
                Console.WriteLine($"{i.InstructorFirstName} {i.InstructorLastName} is in {i.Cohort.CohortName}");
            };
            Pause();

            
// Assign an existing exercise to an existing student
            ExerciseIntersection newInt = new ExerciseIntersection()
            {
                ExerciseId = 3,
                StudentId = 4
            };
            repository.AddExerciseIntersection(newInt);
            Console.WriteLine("Assigned an Exercise to an existing student");
            Pause();

            // List<ExerciseIntersection> exerciseIntersections = repository.GetAllExerciseIntersections();????
            Console.WriteLine("List of Exercise Intersections");

            // foreach (ExerciseIntersection j in exerciseIntersections)
                foreach (ExerciseIntersection j in repository.GetAllExerciseIntersections())
             {
                 Console.WriteLine($"{j.ExerciseId} {j.Exercise} {j.StudentId} {j.Student}");
             };
            Pause();


        }
            // ********** METHODS **********
        

        public static void PrintExerciseReport(string title, List<Exercise> exercises)
        {
            Console.WriteLine(title);
            foreach (Exercise exercise in exercises)
            {
                string ExerciseName = exercise.ExerciseName;
                string Language = exercise.Language;
                int Id = exercise.Id;
                Console.WriteLine($"{Id}: {ExerciseName} {Language}");
            }
        }

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
