using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost("create")]
        public async Task<ResponseDTO> CreateUser([FromBody] UserAccount user)
        {
            return await _userAccountService.CreateUser(user);
        }

        [HttpPost("login")]
        public async Task<ResponseDTO> Login([FromQuery] string email, [FromQuery] string password)
        {
            return await _userAccountService.Login(email, password);
        }

        [HttpGet("get")]
        public async Task<ResponseDTO> GetUserById([FromQuery] Guid userId)
        {
            return await _userAccountService.GetUserById(userId);
        }

        [HttpGet("all")]
        public async Task<ResponseDTO> GetAllUsers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return await _userAccountService.GetAllUsers(pageNumber, pageSize);
        }

        [HttpPut("update")]
        public async Task<ResponseDTO> UpdateUser([FromBody] UserAccount user)
        {
            return await _userAccountService.UpdateUser(user);
        }

        [HttpDelete("delete")]
        public async Task<ResponseDTO> DeleteUser([FromQuery] Guid userId)
        {
            return await _userAccountService.DeleteUser(userId);
        }
    }
}
