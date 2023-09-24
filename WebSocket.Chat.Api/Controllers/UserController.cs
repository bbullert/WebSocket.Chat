using Chat.Core.Dto;
using Chat.Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserCreate> _validator;

        public UserController(
            IUserService userService,
            IValidator<UserCreate> validator
            )
        {
            _validator = validator;
            _userService = userService;
        }
    }
}
