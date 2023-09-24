using Chat.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class ChatMessageController : ApiController
    {
        private readonly IChatMessageService _chatMessageService;

        public ChatMessageController(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }
    }
}
