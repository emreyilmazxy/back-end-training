using OkulDeneme.Business.Operetions.Course.Dtos;
using OkulDeneme.Data.Entities;
using OkulDeneme.Data.Repositories;
using OkulDeneme.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Business.Operetions.Course
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<CourseEntity> _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork,IRepository<CourseEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = repository;
        }

        public Task<CourseDto> AddCourseAsync(CourseDto courseDto)
        {
            var courseEntity = _courseRepository.GetAll(x => x.Title == courseDto.Title).Select( x=> new { 
                gggg = x.Title,
                gagaa =x.Students,

            } );
        }
    }// end of CourseService class
}
