using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Contract
{
    public interface IJwtService
    {
        public string GenerateAccessToken(UserAccount user);
        public string GenerateRefreshToken();
    }
}
