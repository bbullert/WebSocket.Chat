using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class ChatMessageController
    {
        [HttpGet("chats/{chatId}/messages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLatestChatMessages(int chatId, int offset = 0, int count = 30)
        {
            try
            {
                var result = await _chatMessageService.GetLatestChatMessages(chatId, offset, count);
                return Ok(result);
            }
            catch (HttpRequestException ex)
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
