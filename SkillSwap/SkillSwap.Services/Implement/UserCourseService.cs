using SkillSwap.Commons.DTO.BusinessCode;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Implement
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IGenericRepository<UserCourse> _userCourseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserCourseService(IGenericRepository<UserCourse> userCourseRepository, IUnitOfWork unitOfWork)
        {
            _userCourseRepository = userCourseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO> CreateUserCourse(UserCourse userCourse)
        {
            var dto = new ResponseDTO();
            try
            {
                userCourse.UserCourseID = Guid.NewGuid();

                await _userCourseRepository.Insert(userCourse);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.INSERT_SUCESSFULLY;
                dto.Data = userCourse;
            }
            catch (Exception)
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetUserCourseById(Guid userCourseId)
        {
            var dto = new ResponseDTO();
            try
            {
                var result = await _userCourseRepository.GetById(userCourseId);
                if (result == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

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

        public async Task<ResponseDTO> GetAllUserCourses(int pageNumber, int pageSize)
        {
            var dto = new ResponseDTO();
            try
            {
                var result = await _userCourseRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    orderBy: uc => uc.UserCourseID,
                    isAscending: false,
                    includes: new Expression<Func<UserCourse, object>>[]
                    {
                        uc => uc.UserAccount,
                        uc => uc.Course
                    }
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

        public async Task<ResponseDTO> UpdateUserCourse(UserCourse userCourse)
        {
            var dto = new ResponseDTO();
            try
            {
                var existing = await _userCourseRepository.GetById(userCourse.UserCourseID);
                if (existing == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                existing.UserID = userCourse.UserID;
                existing.CourseID = userCourse.CourseID;

                await _userCourseRepository.Update(existing);
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

        public async Task<ResponseDTO> DeleteUserCourse(Guid userCourseId)
        {
            var dto = new ResponseDTO();
            try
            {
                var deleted = await _userCourseRepository.DeleteById(userCourseId);
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
