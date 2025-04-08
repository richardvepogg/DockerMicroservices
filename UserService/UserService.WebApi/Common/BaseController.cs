using Microsoft.AspNetCore.Mvc;
using UserService.WebApi.Common;

namespace UserService.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected IActionResult Ok<T>(T data, string message) =>
            base.Ok(new ApiResponseWithData<T> { Data = data, Success = true, Message = message});

        protected IActionResult Created<T>(string routeName, object routeValues, T data) =>
              base.CreatedAtRoute(routeName, routeValues, new ApiResponseWithData<T> { Data = data, Success = true });

        protected IActionResult BadRequest(string message) =>
            base.BadRequest(new ApiResponse { Message = message, Success = false });

        protected IActionResult NotFound(string message = "Resource not found") =>
            base.NotFound(new ApiResponse { Message = message, Success = false });
    }

    

    
}