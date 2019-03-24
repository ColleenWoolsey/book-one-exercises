/* This is the class we use to interact with our database */
using StudentExercisesPart4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StudentExercisesPart4.Data
{
    public class Repository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Server=DESKTOP-BU9FGRB\\SQLEXPRESS;Database=StudentExercisesDB;Trusted_Connection=True;";
                return new SqlConnection(_connectionString);

            }
        }

        // 1. Query the database for all the Exercises.
        public List<Exercise> GetAllExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, ExerciseName, Language FROM Exercise";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        // This shows the three individual steps
                        /* int idColumnPosition = reader.GetOrdinal("Id");
                         int idValue = reader.GetInt32(idColumnPosition);

                         int exerciseNameColumnPosition = reader.GetOrdinal("ExerciseName");
                         string exerciseNameValue = reader.GetString(exerciseNameColumnPosition);

                         int languageColumnPosition = reader.GetOrdinal("Language");
                         string languageValue = reader.GetString(languageColumnPosition); */

                        int idValue = reader.GetInt32(reader.GetOrdinal("Id"));
                        string exerciseNameValue = reader.GetString(reader.GetOrdinal("ExerciseName"));
                        string languageValue = reader.GetString(reader.GetOrdinal("Language"));

                        // Now let's create a new exercise object using the data from the database.
                        Exercise exercise = new Exercise()
                        {
                            Id = idValue,
                            ExerciseName = exerciseNameValue,
                            Language = languageValue
                        };

                        // ...and add that exercise object to our list.
                        exercises.Add(exercise);
                    }
                    reader.Close();
                    return exercises;
                }
            }
        }


        // 2. Find all the exercises in the database where the language is JavaScript
        public List<Exercise> GetAllJavaScriptExercises(string language)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Exercise e
                                        WHERE e.Language = @language";
                    cmd.Parameters.Add(new SqlParameter("@language", language));

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Exercise> exercises = new List<Exercise>();
                    while (reader.Read())
                    {
                        // This can be reduced from two steps to one step
                        // int idValue = reader.GetInt32(reader.GetOrdinal("Id"));
                        // string exerciseNameValue = reader.GetString(reader.GetOrdinal("ExerciseName"));
                        // string languageValue = reader.GetString(reader.GetOrdinal("Language"));
                        // Exercise exercise = new Exercise()
                        // {Id = idValue,ExerciseName = exerciseNameValue,Language = languageValue};

                        Exercise exercise = new Exercise()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            Language = reader.GetString(reader.GetOrdinal("Language"))
                        };

                        exercises.Add(exercise);
                    }
                    reader.Close();
                    return exercises;
                }
            }
        }


        // Insert a new exercise into the database
        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Trying to make it not add the exercise if already in Table, but not working
                    //  cmd.CommandText = $"SELECT Id FROM Exercise WHERE exercise.ExerciseName != ExerciseName";
                    //  SqlDataReader reader = cmd.ExecuteReader();

                    //  if (reader.IsDBNull(reader.GetOrdinal("Id")))
                    // { ... include cmd.CommandText.Txt.... in if brackets }

                    cmd.CommandText = @"INSERT INTO Exercise
                                         VALUES (@exerciseName, @exerciseLanguage)";
                    cmd.Parameters.Add(new SqlParameter("@exerciseName", exercise.ExerciseName));
                    cmd.Parameters.Add(new SqlParameter("@exerciseLanguage", exercise.Language));
                    cmd.ExecuteNonQuery();

                }
            }
        }

        // FIND all instructors in the Table. Include each instructor's cohort
        public List<Instructor> GetAllInstructorsWithCohort()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Instructor i
                                            INNER JOIN Cohort c ON c.id = i.CohortId";

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Instructor> instructors = new List<Instructor>();
                    while (reader.Read())
                    {
                        Cohort cohort = new Cohort()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("CohortId")),
                            CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                        };
                        Instructor instructor = new Instructor()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            InstructorFirstName = reader.GetString(reader.GetOrdinal("InstructorFirstName")),
                            InstructorLastName = reader.GetString(reader.GetOrdinal("InstructorLastName")),
                            InstructorSlackHandle = reader.GetString(reader.GetOrdinal("InstructorSlackHandle")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId")),
                            Cohort = cohort
                        };
                        instructors.Add(instructor);
                    }
                    reader.Close();
                    return instructors;
                }
            }
        }


        // INSERT a new instructor into the database - Assign the instructor to an existing cohort (Implied??)
        public void AddInstructor(Instructor instructor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Instructor
                                        VALUES (@firstName, @lastName, @slackHandle, @cohortId)";
                    cmd.Parameters.Add(new SqlParameter("@firstName", instructor.InstructorFirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", instructor.InstructorLastName));
                    cmd.Parameters.Add(new SqlParameter("@slackHandle", instructor.InstructorSlackHandle));
                    cmd.Parameters.Add(new SqlParameter("@cohortid", instructor.CohortId));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // My (overly simplified way) of assigning an existing exercise to an existing student.
        // INSERT a new ExerciseIntersection
        public void AddExerciseIntersection(ExerciseIntersection exerciseIntersection)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO ExerciseIntersection
                                        VALUES (@studentId, @exerciseId)";
                    cmd.Parameters.Add(new SqlParameter("@studentId", exerciseIntersection.StudentId));
                    cmd.Parameters.Add(new SqlParameter("@exerciseId", exerciseIntersection.ExerciseId));
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // THEN FIND all Exercise Intersection in the Table - Adding the Student Names and Exercise Name
        // HOWEVER The problem with me making Exercise intersection the main table is I don't see students 
        // without exercises - Where NULL - SO SEE BOTTOM FOR ANDY'S CODE

        public List<ExerciseIntersection> GetAllExerciseIntersections()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT s.StudentFirstName,
                                            s.StudentLastName,
                                            e.ExerciseName,
                                            c.CohortName
                                            From ExerciseIntersection j
                                            RIGHT JOIN Student s on j.StudentId = s.id
                                            RIGHT JOIN Exercise e on j.ExerciseId = e.id
                                            LEFT JOIN Cohort c on s.CohortId = c.id";                    

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ExerciseIntersection> exerciseIntersections = new List<ExerciseIntersection>();
                    while (reader.Read())
                    {
                        ExerciseIntersection exerciseIntersection = new ExerciseIntersection()
                        {
                            StudentId = reader.GetInt32(reader.GetOrdinal("StudentId")),
                            Student = new Student
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                StudentFirstName = reader.GetString(reader.GetOrdinal("StudentFirstName")),
                                StudentLastName = reader.GetString(reader.GetOrdinal("StudentLastName")),
                            },
                            ExerciseId = reader.GetInt32(reader.GetOrdinal("ExerciseId")),
                            Exercise = new Exercise
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            }
                        };
                        exerciseIntersections.Add(exerciseIntersection);
                    }
                    reader.Close();
                    return exerciseIntersections;
                }
            }
        }

        // THIS IS ONLY HELPFUL FOR LISTING MULTIPLE TABLE INFO
        // If we assign an existing exercise to an existing student - Realistically need to see:
        // 1. All the students
        // 2. The exercises they have 
        // 3. All the exercises ... and THEN assign them

        public List<Exercise> GetExerciseIntersections(int studentId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM ExerciseIntersection ei
                                         INNER JOIN Exercise e ON e.Id = ei.ExerciseId
                                         WHERE s.StudentId = @studentId";
                    cmd.Parameters.Add(new SqlParameter("@studentId", studentId));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        Exercise exercise = new Exercise()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ExerciseId")),
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            Language = reader.GetString(reader.GetOrdinal("Language"))
                        };

                        exercises.Add(exercise);
                    }
                    reader.Close();
                    return exercises;
                }
            }
        }

        // Add the following to your program:
        // Find all the students in the database.Include each student's cohort AND each student's list of exercises
        // Write a method in the Repository class that accepts an Exercise and a Cohort and assigns that exercise to 
        // each student in the cohort IF and ONLY IF the student has not already been assigned the exercise.

        // Andy said we needed to write a script in repository that stores the students in a Dictionary instead of a list
        // where the key is the studentId and check to see if student cantains the key
        // When gets to end finds student does contain key and so ContainsKey is false
        // Note: The while loop goes all the way to reader.Close();

        // Note: There are two if statements
        // 1. Have we seen this student before?
        // 2. Do we need to add an exercise?
        // If the student doesn't have any exercises we don't want to create an exercise list

        // Note: In Andy's SELECT statement he created alias names for the Id's and Name field

        // Each value in the return is a Student Value Collection - It's not a list, so have to
        // call .ToList() on return students.Values to give it a container

        public List<Student> GetAllStudents()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select s.id as StudentId,
                                               s.StudentFirstName,
                                               s.StudentLastName,
                                               s.StudentSlackHandle,
                                               s.CohortId,
                                               c.CohortName,
                                               e.id as ExerciseId,
                                               e.ExerciseName,
                                               e.[Language]
                                          from student s
                                               left join Cohort c on s.CohortId = c.id
                                               left join StudentExercise se on s.id = se.studentid
                                               left join Exercise e on se.exerciseid = e.id;";
                    SqlDataReader reader = cmd.ExecuteReader();

                    Dictionary<int, Student> students = new Dictionary<int, Student>();
                    while (reader.Read())
                    {
                        int studentId = reader.GetInt32(reader.GetOrdinal("StudentId"));
                        if (!students.ContainsKey(studentId))
                        {
                            Student newStudent = new Student
                            {
                                Id = studentId,
                                StudentFirstName = reader.GetString(reader.GetOrdinal("StudentFirstName")),
                                StudentLastName = reader.GetString(reader.GetOrdinal("StudentLastName")),
                                StudentSlackHandle = reader.GetString(reader.GetOrdinal("StudentSlackHandle")),
                                CohortId = reader.GetInt32(reader.GetOrdinal("CohortId")),
                                Cohort = new Cohort
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("CohortId")),
                                    CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                                }
                            };

                            students.Add(studentId, newStudent);
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("ExerciseId")))
                        // DBNULL = IF THIS COLUMN IS NOT NULL - There is nothing to add to their exercise list
                        // so need to check if NULL before pass the ordinal of the Id - Only pass if there is an exercise Id)
                        {
                            Student currentStudent = students[studentId];
                            currentStudent.Exercises.Add(
                                new Exercise
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("ExerciseId")),
                                    Language = reader.GetString(reader.GetOrdinal("Language")),
                                    ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                                }
                            );
                        }
                    }

                    reader.Close();

                    return students.Values.ToList();
                }
            }
        }
    }
}
 