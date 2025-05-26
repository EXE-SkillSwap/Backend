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
    public class CourseRepository : ICourseRepository
    {
        private readonly SwapSkillDBContext _dbContext;

        public CourseRepository(SwapSkillDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Course> CreateCourse(Course course)
        {
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
            return course;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _dbContext.Courses
                                   .Include(c => c.Material)
                                   .ToListAsync();
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await _dbContext.Courses
                                   .Include(c => c.Material)
                                   .FirstOrDefaultAsync(c => c.CourseID == id);
        }

        public async Task<Course> UpdateCourse(Guid id, Course course)
        {
            var existingCourse = await _dbContext.Courses.FindAsync(id);
            if (existingCourse == null)
            {
                throw new Exception("Course not found");
            }

            existingCourse.CourseName = course.CourseName;
            existingCourse.CourseDetail = course.CourseDetail;
            existingCourse.CoursePrice = course.CoursePrice;
            existingCourse.MaterialID = course.MaterialID;
            existingCourse.CreatedDate = course.CreatedDate;

            await _dbContext.SaveChangesAsync();
            return existingCourse;
        }
    }
}
