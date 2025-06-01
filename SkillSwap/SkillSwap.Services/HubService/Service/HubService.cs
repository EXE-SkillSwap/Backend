using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SkillSwap.Services.HubService;

namespace SkillSwap.Services.HubService.Service
{
    public class HubService : IHubService
    {
        public readonly IHubContext<NotificationHub> _signalRHub;

        public HubService(IHubContext<NotificationHub> signalRHub)
        {
            _signalRHub = signalRHub;
        }

        public async Task SendAsync(string method)
        {
            await _signalRHub.Clients.All.SendAsync(method);
        }
    }
}
