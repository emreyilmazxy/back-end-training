namespace RelationTable.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }

        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
    }
}
