using Chat.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class ChatUserController
    {
        [HttpDelete("chats/{chatId}/users/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Remove(int chatId, int userId)
        {
            try
            {
                var result = _chatUserService.Remove(chatId, userId);
                if (!result)
                    return NotFound();

                return Ok();
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}