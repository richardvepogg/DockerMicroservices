using AuthenticationService.Application.Users.Queries;
using AuthenticationService.Domain.Interfaces.Services;
using AuthenticationService.WebApi.Features.Users.GetUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public static class AuthenticationController
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapPost("/Authenticate", AuthenticateAsync);
        }

        [HttpPost]
        private static async Task<IResult> AuthenticateAsync(GetUserRequest request, IMediator mediator, IMapper mapper, CancellationToken cancellationToken, ITokenService tokenService)
        {
            try
            {
                GetUserQuerie querie = mapper.Map<GetUserQuerie>(request);

                GetUserResult result = await mediator.Send(querie, cancellationToken);

                if (result == null)
                    return Results.Unauthorized();

                return Results.Ok(mapper.Map<GetUserResponse>(request));
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

    }

}
