using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
//********** STUDENT EXERCISES - PART 1 ********** */
        Console.WriteLine(" ");
        Console.WriteLine("  ********** STUDENT EXERCISES - PART 1  ********** ");
                
// Create 4, or more, exercises.
        Exercise PracticeLists = new Exercise ("Practice Lists", "C#");
        Exercise PracticeDict = new Exercise ("Practice Dictionaries", "C#");
        Exercise PracticeMap = new Exercise ("Practice Mapping", "JavaScript");
        Exercise PracticeRoutes = new Exercise ("Practice Routing", "React");
        Exercise ChallengeMap = new Exercise ("Challenge Mapping", "JavaScript");
        Exercise ChallengeRoutes = new Exercise ("Challenge Routing", "React");
        Exercise ChallengeLists = new Exercise ("Challenge Lists", "C#");
        Exercise ChallengeDict = new Exercise ("Challenge Dict", "C#");
        Exercise OverlyExcited = new Exercise ("Overly Excited", "JavaScript");
        Exercise SolarSystem = new Exercise ("SolarSystem", "C#");
        Exercise CarLot = new Exercise ("CarLot", "React");
        Exercise DynamicCards = new Exercise ("DynamicCards", "JavaScript");

// Create 3, or more, cohorts.
        Cohort Cohort28 = new Cohort ("Cohort 28");
        Cohort Cohort29 = new Cohort ("Cohort 29");
        Cohort Cohort30 = new Cohort ("Cohort 30");

// Create 4, or more, students and assign them to one of the cohorts.
        Student TomSmith = new Student("Tom", "Smith", "TomSmith@slack", "Cohort28");
        Student DickSmith = new Student("Dick", "Smith", "DickSmith@slack", "Cohort28");
        Student HarrySmith = new Student("Harry", "Smith", "HarrySmith@slack", "Cohort29");
        Student JaneSmith = new Student("Jane", "Smith", "JaneSmith@slack", "Cohort 29");
        Student LarrySmith = new Student("Larry", "Smith", "LarrySmith@slack", "Cohort29");
        Student KristinSmith = new Student("Kristin", "Smith", "KristinSmith@slack", "Cohort30");
        Student LoshannaSmith = new Student("Loshanna", "Smith", "LoshannaSmith@slack", "Cohort30");
        Student TreSmith = new Student("Tre", "Smith", "TreSmith@slack", "Cohort28");

        Cohort28.CohortStudentList.Add(TomSmith);
        Cohort28.CohortStudentList.Add(DickSmith);
        Cohort29.CohortStudentList.Add(HarrySmith);
        Cohort29.CohortStudentList.Add(JaneSmith);
        Cohort29.CohortStudentList.Add(LarrySmith);
        Cohort30.CohortStudentList.Add(KristinSmith);
        Cohort30.CohortStudentList.Add(LoshannaSmith);
        Cohort28.CohortStudentList.Add(TreSmith);

// Create 3, or more, instructors and assign them to one of the cohorts.
        Instructor JisieDavid = new Instructor("Jisie", "David", "JisieDavid@slack", "Cohort30");
        Instructor AndyCollins = new Instructor("Andy", "Collins", "AndyCollins@slack", "Cohort29");
        Instructor LeahHoefling = new Instructor("Leah", "Hoefling", "LeahHoefling@slack", "Cohort29");

        Cohort30.CohortInstructorList.Add(JisieDavid);
        Cohort29.CohortInstructorList.Add(AndyCollins);
        Cohort29.CohortInstructorList.Add(LeahHoefling);

// Have each instructor assign 2 exercises to each of the students.
        JisieDavid.AssignExercise(ChallengeLists, TomSmith);
        JisieDavid.AssignExercise(PracticeLists, DickSmith);
        JisieDavid.AssignExercise(PracticeLists, HarrySmith);
        JisieDavid.AssignExercise(PracticeLists, JaneSmith);
        JisieDavid.AssignExercise(PracticeDict, TomSmith);
        JisieDavid.AssignExercise(PracticeDict, DickSmith);
        JisieDavid.AssignExercise(PracticeDict, HarrySmith);
        JisieDavid.AssignExercise(PracticeDict, JaneSmith);

        AndyCollins.AssignExercise(PracticeMap, TomSmith);
        AndyCollins.AssignExercise(PracticeMap, DickSmith);
        AndyCollins.AssignExercise(PracticeMap, HarrySmith);
        AndyCollins.AssignExercise(PracticeMap, JaneSmith);
        AndyCollins.AssignExercise(PracticeRoutes, TomSmith);
        AndyCollins.AssignExercise(PracticeRoutes, DickSmith);
        AndyCollins.AssignExercise(PracticeRoutes, TomSmith);
        AndyCollins.AssignExercise(PracticeRoutes, JaneSmith);

        LeahHoefling.AssignExercise(ChallengeMap, TomSmith);
        LeahHoefling.AssignExercise(ChallengeDict, DickSmith);
        LeahHoefling.AssignExercise(ChallengeMap, HarrySmith);
        LeahHoefling.AssignExercise(ChallengeMap, JaneSmith);
        LeahHoefling.AssignExercise(ChallengeRoutes, TomSmith);
        LeahHoefling.AssignExercise(ChallengeRoutes, DickSmith);
        LeahHoefling.AssignExercise(ChallengeRoutes, HarrySmith);
        LeahHoefling.AssignExercise(ChallengeRoutes, TomSmith);

        // This has to be an Instructor.cs method because no other way to indicate instructor
        // when passing type and argument
        // public void AssignExercise(Exercise exercise, Student student) {
        //     student.Exercises.Add(exercise);
        //     ie: JaneSmith.Exercises.Add(ChallengeRoutes);        
        // }

// Create a list of students. Add all of the student instances to it.
        List<Student> students = new List<Student>() {
            TomSmith,
            DickSmith,
            HarrySmith,
            JaneSmith,
            LarrySmith,
            KristinSmith,
            LoshannaSmith,
            TreSmith
        };
// Create a list of exercises. Add all of the exercise instances to it.
        List<Exercise> exercises = new List<Exercise>() {
            PracticeLists,
            PracticeDict,
            PracticeMap,
            PracticeRoutes,
            ChallengeMap,
            ChallengeRoutes,
            OverlyExcited,
            SolarSystem,
            CarLot,
            DynamicCards
        };

// Generate a report that displays which students are working on which exercises.

        foreach (Student studentRecord in students) {
            List<string> oneStudentsExercises = new List<string>();
                        
            foreach (Exercise oneStudentsExercise in studentRecord.TheStudentsExerciseList) {
                oneStudentsExercises.Add(oneStudentsExercise.ExerciseName);
            }

            string exerciseListString = string.Join(", ", oneStudentsExercises);
            Console.WriteLine(" ");  
            Console.WriteLine($"***** Exercises for: {studentRecord.StudentFirstName}{studentRecord.StudentLastName} *****"); 
            Console.WriteLine($"{exerciseListString}");                
        }


//********** STUDENT EXERCISES - PART 2 ********** */
//     Assigning Student Exercises with LINQ

        List<Cohort> cohorts = new List<Cohort>() {
            Cohort28,
            Cohort29,
            Cohort30
        };

        List<Instructor> instructors = new List<Instructor>() {
            JisieDavid,
            AndyCollins,
            LeahHoefling
        };

        Console.WriteLine("Cohort 28");
        Cohort28.ListInstructors();
        Cohort28.ListStudents();
        Console.WriteLine(" ");
        Console.WriteLine("Cohort 29");
        Cohort29.ListInstructors();
        Cohort29.ListStudents();
        Console.WriteLine(" ");
        Console.WriteLine("Cohort 30");
        Cohort30.ListInstructors();
        Cohort30.ListStudents();
        Console.WriteLine(" ");
        

// Same for instructors and cohorts
// List exercises for the JavaScript language by using the Where() LINQ method.
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine("  ********** STUDENT EXERCISES - PART 2 ********** ");
        Console.WriteLine(" ");
        Console.WriteLine(" ** Exercises in JavaScript **");
        var exercisesList = from exercise in exercises 
                where exercise.Language == "JavaScript"
                select exercise;
        foreach (Exercise j in exercisesList) {
                Console.WriteLine($"     {j.ExerciseName}");
                };

// List students in a particular cohort by using the Where() LINQ method.
        Console.WriteLine(" ");
        Console.WriteLine(" ** Students in Cohort 28 **");
        var cohort28List = from student in students
                where student.CohortName == "Cohort28"
                select student;
        foreach (Student s in cohort28List) {
                Console.WriteLine($"     {s.StudentFirstName} {s.StudentLastName}");
                };

// List instructors in a particular cohort by using the Where() LINQ method.
        Console.WriteLine(" ");
        Console.WriteLine(" ** Instructor(s) in Cohort 29 **");
        var cohort29List = from instructor in instructors
                where instructor.CohortName == "Cohort29"
                select instructor;
        foreach (Instructor item in cohort29List) {
                Console.WriteLine($"     {item.InstructorFirstName} {item.InstructorLastName}");
                };

// Sort the students by their last name.
        Console.WriteLine(" ");
        Console.WriteLine(" ** Students sorted by first name **");
        var studentLastNameSort = from student in students
                orderby student.StudentFirstName
                select student;
        foreach (Student s in studentLastNameSort) {
                Console.WriteLine($"     {s.StudentFirstName} {s.StudentLastName}");
                };

// Display any students that aren't working on any exercises 
// (Make sure one of your student instances don't have any exercises.
    Console.WriteLine(" ");
    Console.WriteLine(" ** Students not working on exercises **");
        var studentNotWorkingList = from student in students
                where student.TheStudentsExerciseList.Count == 0
                select student;
        foreach (Student s in studentNotWorkingList) {
                Console.WriteLine($"     {s.StudentFirstName} {s.StudentLastName}");
                };

// Which student is working on the most exercises? 
// Make sure one of your students has more exercises than the others.
        Console.WriteLine(" ");
        Console.WriteLine(" ** Student working on the most exercises **");
        var studentMostWorking = from student in students
                orderby student.TheStudentsExerciseList.Count descending
                select student;
        
        Console.WriteLine($"     {students[0].StudentFirstName} {students[0].StudentLastName} is working on the most exercises");

        foreach (Student s in studentMostWorking) {
                Console.WriteLine($"     {s.StudentFirstName} {s.StudentLastName} {s.TheStudentsExerciseList.Count}");
                };

// How many students in each cohort?
        Console.WriteLine(" ");
        Console.WriteLine(" ** How many students in each cohort **");
        
        foreach (Cohort c in cohorts) {
            var studentsPerCohort = c.CohortStudentList.Count;
                Console.WriteLine($"   There are {c.CohortStudentList.Count} students in {c.CohortName} ");
        };
        }        
    }
}
