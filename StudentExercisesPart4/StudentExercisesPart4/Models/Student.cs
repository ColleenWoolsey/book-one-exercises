using System;
using System.Collections.Generic;

namespace StudentExercisesPart4.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentSlackHandle { get; set; }
        public string CohortName { get; set; }
        public int CohortId { get; set; }
        public Cohort Cohort { get; set; }
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}