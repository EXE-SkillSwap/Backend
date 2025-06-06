using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;

namespace SkillSwap.Services.Contract
{
    public interface IUserAccountService
    {
        Task<ResponseDTO> CreateUser(UserAccount user);
        Task<ResponseDTO> GetUserById(Guid userId);
        Task<ResponseDTO> GetAllUsers(int pageNumber, int pageSize);
        Task<ResponseDTO> UpdateUser(UserAccount user);
        Task<ResponseDTO> DeleteUser(Guid userId);
        Task<ResponseDTO> Login(string email, string password);
    }
}
