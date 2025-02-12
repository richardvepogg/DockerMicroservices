using AuthenticationService.Application.Users.Queries;
using AuthenticationService.Domain.Interfaces.Services;
using AuthenticationService.WebApi.Features.Users.GetUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Controllers.Common;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IMediator mediator, IMapper mapper, ITokenService tokenService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync(GetUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                GetUserQuerie querie = _mapper.Map<GetUserQuerie>(request);

                GetUserResult result = await _mediator.Send(querie, cancellationToken);

                if (result == null)
                    return Unauthorized("Invalid credentials");

                var response = _mapper.Map<GetUserResponse>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}