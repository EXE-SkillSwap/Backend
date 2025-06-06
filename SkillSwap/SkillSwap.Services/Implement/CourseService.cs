using SkillSwap.Commons.DTO.BusinessCode;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Implement
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IGenericRepository<Course> courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO> CreateCourse(Course course)
        {
            var dto = new ResponseDTO();
            try
            {
                course.CourseID = Guid.NewGuid();
                course.CreatedDate = DateTime.UtcNow;

                await _courseRepository.Insert(course);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.INSERT_SUCESSFULLY;
                dto.Data = course;
            }
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetCourseById(Guid courseId)
        {
            var dto = new ResponseDTO();
            try
            {
                var course = await _courseRepository.GetById(courseId);
                if (course == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = course;
            }
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetAllCourses(int pageNumber, int pageSize)
        {
            var dto = new ResponseDTO();
            try
            {
                var result = await _courseRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    orderBy: c => c.CreatedDate,
                    isAscending: false,
                    includes: c => c.Material
                );

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = result;
            }
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> UpdateCourse(Course course)
        {
            var dto = new ResponseDTO();
            try
            {
                var existing = await _courseRepository.GetById(course.CourseID);
                if (existing == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                existing.CourseName = course.CourseName;
                existing.CourseDetail = course.CourseDetail;
                existing.CoursePrice = course.CoursePrice;
                existing.MaterialID = course.MaterialID;

                await _courseRepository.Update(existing);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.UPDATE_SUCCESSFULLY;
                dto.Data = existing;
            }
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> DeleteCourse(Guid courseId)
        {
            var dto = new ResponseDTO();
            try
            {
                var deleted = await _courseRepository.DeleteById(courseId);
                if (deleted == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.CANCEL_SUCCESSFULLY;
            }
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }
    }
}
