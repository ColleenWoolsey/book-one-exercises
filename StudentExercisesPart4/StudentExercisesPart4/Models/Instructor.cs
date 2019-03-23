using System;
using System.Collections.Generic;

namespace StudentExercisesPart4.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public string InstructorSlackHandle { get; set; }
        public string CohortName { get; set; }
        public int CohortId { get; set; }
        public Cohort Cohort { get; set; }
    }
}