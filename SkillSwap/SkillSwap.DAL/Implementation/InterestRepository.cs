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
    public class InterestRepository : IInterestRepository
    {
        private SwapSkillDBContext _dbContext;
        public InterestRepository(SwapSkillDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Interest> CreateInterest(Interest interest)
        {
            await _dbContext.Interests.AddAsync(interest);
            await _dbContext.SaveChangesAsync();
            return interest;
        }

        public async Task<List<Interest>> SearchByInterest(Guid InterestID)
        {
            var interests = _dbContext.Interests.Where(i => i.InterestID == InterestID).ToList();
            return await Task.FromResult(interests);
        }

        public async Task<Interest> UpdateInterest(Guid id, Interest interest)
        {
            var existingInterest = await _dbContext.Interests.FindAsync(id);
            if (existingInterest != null)
            {
                existingInterest.InterestName = interest.InterestName;
                _dbContext.SaveChanges();
                return await Task.FromResult(existingInterest);
            }
            else
            {
                return await Task.FromResult<Interest>(null);
            }
        }
    }
}
