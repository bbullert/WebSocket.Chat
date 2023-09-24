using Chat.Api.Models;
using Chat.Core.Dto;
using Chat.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class UserController
    {
        [HttpGet("users")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<User>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRangeAsync()
        {
            try
            {
                var result = await _userService.GetAllAsync();
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
