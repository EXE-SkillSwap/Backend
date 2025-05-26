using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Contract
{
    public interface IInterestRepository
    {
        Task<List<Interest>> SearchByInterest(Guid InterestID);
        Task<Interest> CreateInterest(Interest interest);
        Task<Interest> UpdateInterest(Guid id, Interest interest);
    }
}
