using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Contract
{
    public interface IUserCourseService
    {
        Task<ResponseDTO> CreateUserCourse(UserCourse userCourse);
        Task<ResponseDTO> GetUserCourseById(Guid userCourseId);
        Task<ResponseDTO> GetAllUserCourses(int pageNumber, int pageSize);
        Task<ResponseDTO> UpdateUserCourse(UserCourse userCourse);
        Task<ResponseDTO> DeleteUserCourse(Guid userCourseId);
    }
}
