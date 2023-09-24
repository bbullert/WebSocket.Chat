using Chat.Api.Extnesions;
using Chat.Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class MessageController
    {
        [HttpPost("messages")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] MessageCreate model)
        {
            try
            {
                var validationResult = _validator.Validate(model);
                ModelState.AddValidation(validationResult);

                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                var result = await _messageServices.CreateAsync(model);
                return Created(result);
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
