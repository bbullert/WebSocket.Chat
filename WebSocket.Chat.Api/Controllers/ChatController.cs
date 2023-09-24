using Chat.Core.Dto;
using Chat.Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class ChatController : ApiController
    {
        private readonly IChatService _chatService;
        private readonly IValidator<ChatCreate> _validator;

        public ChatController(
            IChatService chatService, 
            IValidator<ChatCreate> validator)
        {
            _chatService = chatService;
            _validator = validator;
        }
    }
}
