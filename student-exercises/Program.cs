using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
        
        // Create 4, or more, exercises.
        Exercise PracticeLists = new Exercise ("Practice Lists", "C#");
        Exercise PracticeDict = new Exercise ("Practice Dictionaries", "C#");
        Exercise PracticeMap = new Exercise ("Practice Mapping", "JavaScript");
        Exercise PracticeRoutes = new Exercise ("Practice Routing", "React");
        Exercise ChallengeMap = new Exercise ("Challenge Mapping", "JavaScript");
        Exercise ChallengeRoutes = new Exercise ("Challenge Routing", "React");
        Exercise ChallengeLists = new Exercise ("Challenge Lists", "C#");
        Exercise ChallengeDict = new Exercise ("Challenge Dict", "C#");

        // Create 3, or more, cohorts.
        Cohort Cohort28 = new Cohort ("Cohort 28");
        Cohort Cohort29 = new Cohort ("Cohort 29");
        Cohort Cohort30 = new Cohort ("Cohort 30");

        // Create 4, or more, students and assign them to one of the cohorts.
        Student TomSmith = new Student("Tom", "Smith", "TomSmith@slack", "Cohort28");
        Student DickSmith = new Student("Dick", "Smith", "DickSmith@slack", "Cohort28");
        Student HarrySmith = new Student("Harry", "Smith", "HarrySmith@slack", "Cohort29");
        Student JaneSmith = new Student("Jane", "Smith", "JaneSmith@slack", "Cohort 29");

        Cohort28.Students.Add(TomSmith);
        Cohort28.Students.Add(DickSmith);
        Cohort29.Students.Add(HarrySmith);
        Cohort29.Students.Add(JaneSmith);

        // Create 3, or more, instructors and assign them to one of the cohorts.
        Instructor JisieDavid = new Instructor("Jisie", "David", "JisieDavid@slack", "Cohort30");
        Instructor AndyCollins = new Instructor("Andy", "Collins", "AndyCollins@slack", "Cohort29");
        Instructor LeahHoefling = new Instructor("Leah", "Hoefling", "LeahHoefling@slack", "Cohort29");

        Cohort30.Instructors.Add(JisieDavid);
        Cohort29.Instructors.Add(AndyCollins);
        Cohort29.Instructors.Add(LeahHoefling);

        Cohort28.ListStudents();
        Cohort28.ListInstructors();
        Cohort29.ListStudents();
        Cohort29.ListInstructors();
        Cohort30.ListStudents();
        Cohort30.ListInstructors(); 

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
        AndyCollins.AssignExercise(PracticeRoutes, HarrySmith);
        AndyCollins.AssignExercise(PracticeRoutes, JaneSmith);

        LeahHoefling.AssignExercise(ChallengeMap, TomSmith);
        LeahHoefling.AssignExercise(ChallengeDict, DickSmith);
        LeahHoefling.AssignExercise(ChallengeMap, HarrySmith);
        LeahHoefling.AssignExercise(ChallengeMap, JaneSmith);
        LeahHoefling.AssignExercise(ChallengeRoutes, TomSmith);
        LeahHoefling.AssignExercise(ChallengeRoutes, DickSmith);
        LeahHoefling.AssignExercise(ChallengeRoutes, HarrySmith);
        LeahHoefling.AssignExercise(ChallengeRoutes, JaneSmith);

        // This has to be an Instructor.cs method because no other way to indicate instructor
        // when passing type and argument
        // public void AssignExercise(Exercise exercise, Student student) {
        //     student.Exercises.Add(exercise);
        //     ie: JaneSmith.Exercises.Add(ChallengeRoutes);        
        // }
        
        // Create a list of students. Add all of the student instances to it.
        List<Student> studentList = new List<Student>() {TomSmith, DickSmith, HarrySmith, JaneSmith};

        // Create a list of exercises. Add all of the exercise instances to it.
        List<Exercise> exerciseList = new List<Exercise>() {
            PracticeLists,
            PracticeDict,
            PracticeMap,
            PracticeRoutes,
            ChallengeMap,
            ChallengeRoutes};

        // Generate a report that displays which students are working on which exercises.

            foreach (Student studentRecord in studentList) {
                List<string> oneStudentsExercises = new List<string>();
                          
                foreach (Exercise oneStudentsExercise in studentRecord.Exercises) {
                    oneStudentsExercises.Add(oneStudentsExercise.ExerciseName);
                }

                string exerciseListString = string.Join(", ", oneStudentsExercises);   
                Console.WriteLine($"***** EXERCISES: {studentRecord.StudentFirstName} {studentRecord.StudentLastName} *****"); 
                Console.WriteLine($"{exerciseListString}");                
            }
        }
        
    }
}
