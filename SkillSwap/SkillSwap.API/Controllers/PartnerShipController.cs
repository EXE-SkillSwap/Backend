using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/partnerShip")]
    [ApiController]
    public class PartnerShipController : ControllerBase
    {
        private readonly IPartnerShipService _partnerShipService;

        public PartnerShipController(IPartnerShipService partnerShipService)
        {
            _partnerShipService = partnerShipService;
        }

        [HttpPost("request_add_friend")]
        public async Task<ResponseDTO> RequestAddFriend(Guid senderId, Guid receiverId)
        {
            return await _partnerShipService.RequestAddFriend(senderId, receiverId);
        }

        [HttpPost("accept_friend_request")]
        public async Task<ResponseDTO> AcceptFriendRequest(Guid senderId, Guid receiverId)
        {
            return await _partnerShipService.AcceptFriendRequest(receiverId, senderId);
        }

        [HttpPost("reject_friend_request")]
        public async Task<ResponseDTO> RejectFriendRequest(Guid receiverId, Guid senderId)
        {
            return await _partnerShipService.RejectFriendRequest(receiverId, senderId);
        }

        [HttpDelete("cancel_friend_request")]
        public async Task<ResponseDTO> CancelFriendRequest(Guid senderId, Guid receiverId)
        {
            return await _partnerShipService.CancelFriendRequest(senderId, receiverId);
        }

        [HttpDelete("remove_friend")]
        public async Task<ResponseDTO> RemoveFriend(Guid userId, Guid friendId)
        {
            return await _partnerShipService.RemoveFriend(userId, friendId);
        }

        [HttpPost("block")]
        public async Task<ResponseDTO> BlockUser(Guid blockerId, Guid blockedId)
        {
            return await _partnerShipService.BlockUser(blockerId, blockedId);
        }

        [HttpPost("unblock")]
        public async Task<ResponseDTO> UnblockUser(Guid blockerId, Guid blockedId)
        {
            return await _partnerShipService.UnblockUser(blockerId, blockedId);
        }

        [HttpGet("list_friend")]
        public async Task<ResponseDTO> GetListFriends(Guid userId, int pageNumber = 1, int pageSize = 10)
        {
            return await _partnerShipService.GetListFriends(userId, pageNumber, pageSize);
        }

        [HttpGet("list_friend_requests")]
        public async Task<ResponseDTO> GetFriendRequests(Guid userId, int pageNumber = 1, int pageSize = 10)
        {
            return await _partnerShipService.GetFriendRequests(userId, pageNumber, pageSize);
        }

        [HttpGet("list_sent_friend_requests")]
        public async Task<ResponseDTO> GetSentFriendRequests(Guid userId, int pageNumber = 1, int pageSize = 10)
        {
            return await _partnerShipService.GetSentFriendRequests(userId, pageNumber, pageSize);
        }


        [HttpGet("suggest_friends")]
        public async Task<ResponseDTO> SuggestFriends(Guid userId, int pageNumber = 1, int pageSize = 10)
        {
            return await _partnerShipService.SuggestFriends(userId, pageNumber, pageSize);
        }
    }
}
