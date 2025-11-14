using OkulDeneme.Business.Operetions.Course.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Business.Operetions.Course
{
    public interface ICourseService
    {
        Task<CourseDto> AddCourseAsync(CourseDto courseDto );
    }// end of ICourseService interface
}
