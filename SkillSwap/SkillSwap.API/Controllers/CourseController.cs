using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    namespace SkillSwap.API.Controllers
    {
        [Route("api/course")]
        [ApiController]
        public class CourseController : ControllerBase
        {
            private readonly ICourseService _courseService;

            public CourseController(ICourseService courseService)
            {
                _courseService = courseService;
            }

            [HttpPost("create")]
            public async Task<ResponseDTO> CreateCourse([FromBody] Course course)
            {
                return await _courseService.CreateCourse(course);
            }

            [HttpGet("get")]
            public async Task<ResponseDTO> GetCourseById([FromQuery] Guid courseId)
            {
                return await _courseService.GetCourseById(courseId);
            }

            [HttpGet("all")]
            public async Task<ResponseDTO> GetAllCourses([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
            {
                return await _courseService.GetAllCourses(pageNumber, pageSize);
            }

            [HttpPut("update")]
            public async Task<ResponseDTO> UpdateCourse([FromBody] Course course)
            {
                return await _courseService.UpdateCourse(course);
            }

            [HttpDelete("delete")]
            public async Task<ResponseDTO> DeleteCourse([FromQuery] Guid courseId)
            {
                return await _courseService.DeleteCourse(courseId);
            }
        }
    }
}
