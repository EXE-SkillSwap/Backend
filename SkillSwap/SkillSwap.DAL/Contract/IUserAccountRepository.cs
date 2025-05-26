using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Contract
{
    public interface IUserAccountRepository
    {
        Task<UserAccount> GetUserById(Guid id);
        Task<List<UserAccount>> GetAllUsers();
        Task<UserAccount> CreateUser(UserAccount user);
        Task<UserAccount> UpdateUser(Guid id, UserAccount user);
        Task<UserAccount?> LoginAsync(string email, string passwordHash);
    }
}
