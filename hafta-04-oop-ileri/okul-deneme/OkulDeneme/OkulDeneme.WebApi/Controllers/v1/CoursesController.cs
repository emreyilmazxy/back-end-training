using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OkulDeneme.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        [HttpPost]
        public  Task<IActionResult> CreateCourse(CourseRequestDto courseDto)
        {
            // Logic to create a course
            return Ok(new { Message = "Course created successfully", Course = courseDto });
        }
    }
}
