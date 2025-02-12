using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Users.Command.CreateUser;
using UserService.Application.Users.Command.DeleteUser;
using UserService.Application.Users.Command.UpdateUser;
using UserService.Application.Users.Queries.GetAllUsers;
using UserService.Application.Users.Queries.GetUser;
using UserService.Controllers.Common;
using UserService.WebApi.Features.Users.CreateUser;
using UserService.WebApi.Features.Users.DeleteUser;
using UserService.WebApi.Features.Users.GetUser;
using UserService.WebApi.Features.Users.UpdateUser;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            try
            {
                GetAllUsersResult result = await _mediator.Send(new GetAllUsersQuerie(), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id, CancellationToken cancellationToken)
        {
            try
            {
                GetUserRequest request = new GetUserRequest { Id = id };

                GetUserQuerie querie = _mapper.Map<GetUserQuerie>(request.Id);
                GetUserResult result = await _mediator.Send(querie, cancellationToken);

                if (result == null) return NotFound();

                GetUserResponse response = _mapper.Map<GetUserResponse>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest user, CancellationToken cancellationToken)
        {
            try
            {
                CreateUserCommand command = _mapper.Map<CreateUserCommand>(user);

                CreateUserResult result = await _mediator.Send(command, cancellationToken);

                if (result == null) return BadRequest("Failed to create user");

                GetUserResponse response = _mapper.Map<GetUserResponse>(result);
                return Created("GetUser", new { response.id }, response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest user, CancellationToken cancellationToken)
        {
            try
            {
                UpdateUserCommand command = _mapper.Map<UpdateUserCommand>(user);

                UpdateUserResult? result = await _mediator.Send(command, cancellationToken);

                if (result == null) return BadRequest("Failed to update user");

                UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                DeleteUserRequest request = new DeleteUserRequest { Id = id };
                DeleteUserCommand command = _mapper.Map<DeleteUserCommand>(request.Id);
                await _mediator.Send(command, cancellationToken);

                return Ok("The user was successfully deleted!");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}