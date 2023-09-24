using Chat.Api.Extnesions;
using Chat.Core.Dto;
using Chat.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class UserController
    {
        [HttpPost("users/json")]
        //[ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ApiResponse<ValidationResult>), StatusCodes.Status422UnprocessableEntity)]
        //[ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateFromJsonAsync(IFormFile? file)
        {
            try
            {
                var result = await _userService.CreateFromJsonAsync(file);
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
