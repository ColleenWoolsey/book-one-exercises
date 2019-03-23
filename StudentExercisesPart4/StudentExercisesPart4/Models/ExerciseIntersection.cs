/* This is the class we use to interact with our database */
namespace StudentExercisesPart4.Models
{
    public class ExerciseIntersection
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExerciseId { get; set; }
        public object Exercise { get; internal set; }
        public object Student { get; internal set; }
    }
}