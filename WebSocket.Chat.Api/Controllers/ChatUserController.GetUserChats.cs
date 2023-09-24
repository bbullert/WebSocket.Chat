using Chat.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class ChatUserController
    {
        [HttpGet("users/{userId}/chats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserChatsAsync(int userId)
        {
            try
            {
                var result = await _chatUserService.GetUserChatsAsync(userId);
                return Ok(result);
            }
            catch (HttpResponseException ex)
            {
                return Error(ex);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
