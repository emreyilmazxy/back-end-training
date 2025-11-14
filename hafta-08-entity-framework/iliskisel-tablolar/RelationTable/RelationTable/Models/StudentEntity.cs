namespace RelationTable.Models
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Öğrencinin aldığı derslerin listesi
        public List<StudentEntity> StudentCourses { get; set; }
    }
}
