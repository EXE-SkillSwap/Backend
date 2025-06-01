using System;
using System.Threading.Tasks;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Enum;


namespace SkillSwap.Services.Contract
{
    public interface IMessageService
    {
        Task<ResponseDTO> SendMessage(Guid senderId, Guid conversationId, string content);
        Task<ResponseDTO> GetMessages(Guid conversationId, int pageNumber, int pageSize);
        Task<ResponseDTO> UpdateMessageStatus(Guid messageId, MessageStatus status);
        Task<ResponseDTO> DeleteMessage(Guid messageId, Guid requesterId);
    }
}
