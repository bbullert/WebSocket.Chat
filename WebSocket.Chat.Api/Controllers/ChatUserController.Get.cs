using Chat.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class ChatUserController
    {
        [HttpGet("chats/{chatId}/users/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int chatId, int userId)
        {
            try
            {
                var result = await _chatUserService.GetAsync(chatId, userId);
                if (result == null)
                    return NotFound();

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
