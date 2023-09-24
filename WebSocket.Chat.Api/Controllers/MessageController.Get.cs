﻿using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public partial class MessageController
    {
        [HttpGet("messages/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await _messageServices.GetAsync(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
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
