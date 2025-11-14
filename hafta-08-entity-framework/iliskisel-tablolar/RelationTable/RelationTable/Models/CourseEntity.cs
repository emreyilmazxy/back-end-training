namespace RelationTable.Models
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Dersin alındığı öğrencilerin listesi
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
