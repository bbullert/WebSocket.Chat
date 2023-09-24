using Chat.Api.Extnesions;
using Chat.Api.Models;
using Chat.Core.Dto;
using Chat.Core.Exceptions;
using Chat.Core.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class ChatController
    {
        [HttpPost("chats")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ValidationResult>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] ChatCreate model)
        {
            try
            {
                var validationResult = _validator.Validate(model);
                ModelState.AddValidation(validationResult);

                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                var result = await _chatService.CreateAsync(model);
                return Created(result);
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
