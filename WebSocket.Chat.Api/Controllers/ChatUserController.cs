using Chat.Core.Dto;
using Chat.Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class ChatUserController : ApiController
    {
        private readonly IChatUserService _chatUserService;
        private readonly IValidator<ChatUserCreate> _validator;

        public ChatUserController(
            IChatUserService chatUserService,
            IValidator<ChatUserCreate> validator
            )
        {
            _chatUserService = chatUserService;
            _validator = validator;
        }
    }
}
