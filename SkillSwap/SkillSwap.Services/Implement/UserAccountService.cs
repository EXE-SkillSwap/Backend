using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SkillSwap.Commons.DTO;
using SkillSwap.Commons.DTO.BusinessCode;
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.Services.Implement
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IGenericRepository<UserAccount> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public UserAccountService(
            IGenericRepository<UserAccount> userRepository,
            IUnitOfWork unitOfWork,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<ResponseDTO> CreateUser(UserAccount user)
        {
            var dto = new ResponseDTO();
            try
            {
                var existingUser = await _userRepository.GetFirstByExpression(
                    u => u.Email.ToLower() == user.Email.ToLower()
                );

                if (existingUser != null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.EXISTED_USER;
                    return dto;
                }

                user.UserID = Guid.NewGuid();
                user.CreatedAt = DateTime.UtcNow;

                await _userRepository.Insert(user);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.SIGN_UP_SUCCESSFULLY;
                dto.Data = new
                {
                    User = user,
                };
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.SIGN_UP_FAILED;
            }
            return dto;
        }


        public async Task<ResponseDTO> GetUserById(Guid userId)
        {
            var dto = new ResponseDTO();
            try
            {
                var user = await _userRepository.GetById(userId);
                if (user == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.AUTH_NOT_FOUND;
                    return dto;
                }

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = user;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetAllUsers(int pageNumber, int pageSize)
        {
            var dto = new ResponseDTO();
            try
            {
                var result = await _userRepository.GetAllDataByExpression(
                filter: null,
                pageNumber: pageNumber,
                pageSize: pageSize,
                orderBy: u => u.CreatedAt,
                isAscending: false,
                includes: new Expression<Func<UserAccount, object>>[]
                {
                    u => u.Role
                }
            );

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = result;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> UpdateUser(UserAccount user)
        {
            var dto = new ResponseDTO();
            try
            {
                var existing = await _userRepository.GetById(user.UserID);
                if (existing == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.AUTH_NOT_FOUND;
                    return dto;
                }

                existing.FullName = user.FullName;
                existing.Gender = user.Gender;
                existing.Email = user.Email;
                existing.Address = user.Address;
                existing.DateOfBirth = user.DateOfBirth;
                existing.PasswordHash = user.PasswordHash;
                existing.RoleID = user.RoleID;

                await _userRepository.Update(existing);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.UPDATE_SUCCESSFULLY;
                dto.Data = existing;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> DeleteUser(Guid userId)
        {
            var dto = new ResponseDTO();
            try
            {
                var deleted = await _userRepository.DeleteById(userId);
                if (deleted == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.AUTH_NOT_FOUND;
                    return dto;
                }

                await _unitOfWork.SaveChangeAsync();
                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.CANCEL_SUCCESSFULLY;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> Login(string email, string password)
        {
            var dto = new ResponseDTO();
            try
            {
                var user = await _userRepository.GetFirstByExpression(
                u => u.Email.ToLower() == email.ToLower(),
                u => u.Role
            );

                if (user == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.AUTH_NOT_FOUND;
                    return dto;
                }

                if (user.PasswordHash != password)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.WRONG_PASSWORD;
                    return dto;
                }

                string accessToken = _jwtService.GenerateAccessToken(user);
                string refreshToken = _jwtService.GenerateRefreshToken();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = new
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    UserInfo = new
                    {
                        user.UserID,
                        user.FullName,
                        user.Email,
                        Role = user.Role?.RoleName
                    }
                };
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }
    }
}
