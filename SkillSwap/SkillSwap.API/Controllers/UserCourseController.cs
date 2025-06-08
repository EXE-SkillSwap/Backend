using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/user-course")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseService _userCourseService;

        public UserCourseController(IUserCourseService userCourseService)
        {
            _userCourseService = userCourseService;
        }

        [HttpPost("create")]
        public async Task<ResponseDTO> CreateUserCourse([FromBody] UserCourse userCourse)
        {
            return await _userCourseService.CreateUserCourse(userCourse);
        }

        [HttpGet("get")]
        public async Task<ResponseDTO> GetUserCourseById([FromQuery] Guid userCourseId)
        {
            return await _userCourseService.GetUserCourseById(userCourseId);
        }

        [HttpGet("all")]
        public async Task<ResponseDTO> GetAllUserCourses([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return await _userCourseService.GetAllUserCourses(pageNumber, pageSize);
        }

        [HttpPut("update")]
        public async Task<ResponseDTO> UpdateUserCourse([FromBody] UserCourse userCourse)
        {
            return await _userCourseService.UpdateUserCourse(userCourse);
        }

        [HttpDelete("delete")]
        public async Task<ResponseDTO> DeleteUserCourse([FromQuery] Guid userCourseId)
        {
            return await _userCourseService.DeleteUserCourse(userCourseId);
        }
    }
}