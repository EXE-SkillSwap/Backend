using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.HubService.Service
{
    public interface IHubService
    {
        Task SendAsync(string method);
    }
}
