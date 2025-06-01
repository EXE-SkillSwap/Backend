using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSwap.Commons.DTO;
using SkillSwap.Services.Contract;

namespace SkillSwap.Services.Implement
{
    public class PartnerShipService : IPartnerShipService
    {
        public Task<ResponseDTO> AcceptFriendRequest(Guid receiverId, Guid senderId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> BlockUser(Guid blockerId, Guid blockedId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> CancelFriendRequest(Guid senderId, Guid receiverId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> GetFriendRequests(Guid userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> GetListFriends(Guid userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> GetSentFriendRequests(Guid userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> RejectFriendRequest(Guid receiverId, Guid senderId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> RemoveFriend(Guid userId, Guid friendId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> RequestAddFriend(Guid senderId, Guid receiverId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> SuggestFriends(Guid userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> UnblockUser(Guid blockerId, Guid blockedId)
        {
            throw new NotImplementedException();
        }
    }
}
