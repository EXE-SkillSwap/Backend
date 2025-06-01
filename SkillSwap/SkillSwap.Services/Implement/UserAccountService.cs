using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSwap.Commons.DTO;
using SkillSwap.Services.Contract;

namespace SkillSwap.Services.Implement
{
    public class UserAccountService : IUserAccountService
    {
        public Task<ResponseDTO> CreateUserAccount(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
