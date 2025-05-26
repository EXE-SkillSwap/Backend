using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Contract
{
    public interface IUserCourseRepository
    {
        Task<UserCourse> GetUserCourseById(Guid id);
        Task<List<UserCourse>> GetAllUserCourses();
        Task<UserCourse> CreateUserCourse(UserCourse userCourse);
        Task<UserCourse> UpdateUserCourse(Guid id, UserCourse userCourse);
    }
}
