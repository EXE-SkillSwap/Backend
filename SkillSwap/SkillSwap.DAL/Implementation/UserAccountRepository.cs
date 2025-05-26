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
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly SwapSkillDBContext _dbContext;

        public UserAccountRepository(SwapSkillDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserAccount> CreateUser(UserAccount user)
        {
            await _dbContext.UserAccounts.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserAccount>> GetAllUsers()
        {
            return await _dbContext.UserAccounts
                                   .Include(u => u.Role)
                                   .Include(u => u.Interest)
                                   .ToListAsync();
        }

        public async Task<UserAccount?> GetUserById(Guid id)
        {
            return await _dbContext.UserAccounts
                                   .Include(u => u.Role)
                                   .Include(u => u.Interest)
                                   .FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<UserAccount> UpdateUser(Guid id, UserAccount user)
        {
            var existingUser = await _dbContext.UserAccounts.FindAsync(id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.Gender = user.Gender;
            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.Address = user.Address;
            existingUser.RoleID = user.RoleID;
            existingUser.InterestID = user.InterestID;
            existingUser.PartnerAmount = user.PartnerAmount;

            await _dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<UserAccount?> LoginAsync(string email, string passwordHash)
        {
            return await _dbContext.UserAccounts
                                   .Include(u => u.Role)
                                   .FirstOrDefaultAsync(u =>
                                       u.Email == email && u.PasswordHash == passwordHash);
        }
    }
}
