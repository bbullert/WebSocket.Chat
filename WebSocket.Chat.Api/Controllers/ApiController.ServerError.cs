using Chat.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Chat.Api.Controllers
{
    public partial class ApiController : ControllerBase
    {
        protected virtual ObjectResult InternalServerError(Exception ex)
        {
            var response = new ApiResponse<object>()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Details = "An unexpected error has occurred"
            };

            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
    }
}