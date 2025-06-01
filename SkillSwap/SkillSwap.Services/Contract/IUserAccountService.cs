using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSwap.Commons.DTO;

namespace SkillSwap.Services.Contract
{
    public interface IUserAccountService
    {
        Task<ResponseDTO> CreateUserAccount(string username, string email);
    }
}
