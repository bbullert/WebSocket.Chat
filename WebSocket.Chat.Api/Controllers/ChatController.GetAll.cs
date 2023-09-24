using Chat.Api.Models;
using Chat.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class ChatController
    {
        [HttpGet("chats")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<Chat.Core.Dto.Chat>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRangeAsync()
        {
            try
            {
                var result = await _chatService.GetAllAsync();
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
