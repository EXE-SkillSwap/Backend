using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Enum;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("send")]
        public async Task<ResponseDTO> SendMessage(Guid senderId, Guid conversationId, string content)
        {
            return await _messageService.SendMessage(senderId, conversationId, content);
        }

        [HttpGet("conversation_messages")]
        public async Task<ResponseDTO> GetMessages(Guid conversationId, int pageNumber = 1, int pageSize = 10)
        {
            return await _messageService.GetMessages(conversationId, pageNumber, pageSize);
        }

        [HttpDelete("delete")]
        public async Task<ResponseDTO> DeleteMessage(Guid messageId, Guid requesterId)
        {
            return await _messageService.DeleteMessage(messageId, requesterId);
        }

        [HttpPut("update_status")]
        public async Task<ResponseDTO> UpdateMessageStatus(Guid messageId, int status)
        {
            return await _messageService.UpdateMessageStatus(messageId, (MessageStatus)status);
        }
    }
}
