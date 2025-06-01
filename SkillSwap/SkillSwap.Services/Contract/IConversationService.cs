using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillSwap.Commons.DTO;


namespace SkillSwap.Services.Contract
{
    public interface IConversationService
    {
        Task<ResponseDTO> CreateConversation(Guid creatorId, string name, List<Guid> memberIds, bool isGroup);
        Task<ResponseDTO> GetUserConversations(Guid userId, int pageNumber, int pageSize);
        Task<ResponseDTO> DeleteConversation(Guid conversationId, Guid requesterId);

    }
}