using Microsoft.EntityFrameworkCore;
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Data;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Implementation
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly SwapSkillDBContext _dbContext;

        public UserCourseRepository(SwapSkillDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserCourse> CreateUserCourse(UserCourse userCourse)
        {
            await _dbContext.UserCourses.AddAsync(userCourse);
            await _dbContext.SaveChangesAsync();
            return userCourse;
        }

        public async Task<List<UserCourse>> GetAllUserCourses()
        {
            return await _dbContext.UserCourses
                                   .Include(uc => uc.UserAccount)
                                   .Include(uc => uc.Course)
                                   .ToListAsync();
        }

        public async Task<UserCourse> GetUserCourseById(Guid id)
        {
            return await _dbContext.UserCourses
                                   .Include(uc => uc.UserAccount)
                                   .Include(uc => uc.Course)
                                   .FirstOrDefaultAsync(uc => uc.UserCourseID == id);
        }

        public async Task<UserCourse> UpdateUserCourse(Guid id, UserCourse userCourse)
        {
            var existingUserCourse = await _dbContext.UserCourses.FindAsync(id);
            if (existingUserCourse == null)
            {
                throw new Exception("UserCourse not found");
            }

            existingUserCourse.UserID = userCourse.UserID;
            existingUserCourse.CourseID = userCourse.CourseID;

            await _dbContext.SaveChangesAsync();
            return existingUserCourse;
        }
    }
}
