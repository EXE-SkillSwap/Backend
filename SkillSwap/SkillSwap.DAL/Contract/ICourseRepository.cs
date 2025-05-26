using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Contract
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseById(Guid id);
        Task<List<Course>> GetAllCourses();
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(Guid id, Course course);
    }
}
