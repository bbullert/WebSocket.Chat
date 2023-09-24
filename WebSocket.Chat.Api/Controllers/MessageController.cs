using Chat.Core.Dto;
using Chat.Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class MessageController : ApiController
    {
        private readonly IMessageService _messageServices;
        private readonly IValidator<MessageCreate> _validator;

        public MessageController(
            IMessageService messageServices, 
            IValidator<MessageCreate> validator)
        {
            _messageServices = messageServices;
            _validator = validator;
        }
    }
}
