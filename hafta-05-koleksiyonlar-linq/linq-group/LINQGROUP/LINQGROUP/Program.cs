using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQGROUP
{


    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {

    new Student { StudentId = 1, StudentName = "Ayşe Demir", ClassId = 1 },
    new Student { StudentId = 2, StudentName = "Mehmet Yılmaz", ClassId = 3 },
    new Student { StudentId = 3, StudentName = "Zeynep Kara", ClassId = 2 },
    new Student { StudentId = 4, StudentName = "Ali Şahin", ClassId = 4 },
    new Student { StudentId = 5, StudentName = "Fatma Aksoy", ClassId = 5 },
    new Student { StudentId = 6, StudentName = "Emre Arslan", ClassId = 1 },
    new Student { StudentId = 7, StudentName = "Hüseyin Aydın", ClassId = 3 },
    new Student { StudentId = 8, StudentName = "Hatice Koç", ClassId = 2 },
    new Student { StudentId = 9, StudentName = "Deniz Uçar", ClassId = 4 },
    new Student { StudentId = 10, StudentName = "Melis Güneş", ClassId = 5 }
};



            List<Classes> classes = new List<Classes>
            {
                new Classes { ClassId = 1, ClassName = "Matematik" },
                new Classes { ClassId = 2, ClassName = "Fizik" },
                new Classes { ClassId = 3, ClassName = "Kimya" },
                new Classes { ClassId = 4, ClassName = "Biyoloji" },
                new Classes { ClassId = 5, ClassName = "Tarih" }
            };


            var result = classes.GroupJoin(students,cls => cls.ClassId,std=> std.ClassId,
                                                              (cls,studenGroup) => new 
                                                              {
                                                                    className = cls.ClassName,
                                                                    students = studenGroup.Select(s => s.StudentName)
                                                              }
            );

            foreach (var item in result)
            {
                Console.WriteLine($"Class: {item.className}");
                foreach (var student in item.students)
                {
                    Console.WriteLine($" - Student: {student}");
                }
            }

          ////  var result2 = from cls in classes
          //                join std in students on cls.ClassId equals std.ClassId into studentGroup
          //                select new
          //                {
          //                    ClassName = cls.ClassName,
          //                    Students = studentGroup.Select(s => s.StudentName)
          //                };


        }
    }
}