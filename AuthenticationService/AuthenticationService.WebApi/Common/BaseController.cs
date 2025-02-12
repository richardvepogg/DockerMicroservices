using AuthenticationService.WebApi.Common;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Ok<T>(T data) =>
            base.Ok(new ApiResponseWithData<T> { Data = data, Success = true });

        protected IActionResult Unauthorized(string message = "Unauthorized") =>
            base.Unauthorized(new ApiResponse { Message = message, Success = false });

        protected IActionResult Problem(string message) =>
            base.Problem(new ApiResponse { Message = message, Success = false }.ToString());
    }


}