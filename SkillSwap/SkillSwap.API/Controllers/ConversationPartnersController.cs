using Azure;
using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/conversation_partner")]
    [ApiController]
    public class ConversationPartnersController : ControllerBase
    {
        private readonly IConversationPartnersService _conversationPartnersService;

        public ConversationPartnersController(IConversationPartnersService conversationPartnersService)
        {
            _conversationPartnersService = conversationPartnersService;
        }

        [HttpPost("add_member")]
        public async Task<ResponseDTO> AddMemberToGroup (Guid conversationId, Guid userId)
        {
            return await _conversationPartnersService.AddMemberToGroup(conversationId, userId);
        }

        [HttpDelete("leave_group")]
        public async Task<ResponseDTO> LeaveGroup(Guid conversationId, Guid userId)
        {
            return await _conversationPartnersService.LeaveGroup(conversationId, userId);
        }

        [HttpGet("members")]
        public async Task<ResponseDTO> GetConversationPartners(Guid conversationId)
        {
            return await _conversationPartnersService.GetConversationMembers(conversationId);
        }
    }
}
