using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Contract
{
    public interface ICourseService
    {
        Task<ResponseDTO> CreateCourse(Course course);
        Task<ResponseDTO> GetCourseById(Guid courseId);
        Task<ResponseDTO> GetAllCourses(int pageNumber, int pageSize);
        Task<ResponseDTO> UpdateCourse(Course course);
        Task<ResponseDTO> DeleteCourse(Guid courseId);
    }
}
