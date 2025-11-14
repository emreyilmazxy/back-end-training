namespace Dependency_Injection.mODELS
{
    public class ClassRoom
    {
        private readonly ITeacher _teacher;

        public ClassRoom(ITeacher teacher) 
        {
            _teacher = teacher;
        }

        public void GetTeacherInfo()
        {
            Console.WriteLine("Öğretmen: " + _teacher.GetInfo());
        }   
    }
}
