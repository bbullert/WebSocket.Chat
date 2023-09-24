using Chat.Api.Models;
using Chat.Core.Dto;
using Chat.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class UserController
    {
        [HttpGet("users/{id}")]
        [ProducesResponseType(typeof(ApiResponse<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await _userService.GetAsync(id);
                if (result == null)
                    return NotFound();

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
