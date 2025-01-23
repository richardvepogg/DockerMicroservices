using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Users.Command.CreateUser;
using UserService.Application.Users.Command.DeleteUser;
using UserService.Application.Users.Command.UpdateUser;
using UserService.Application.Users.Queries.GetAllUsers;
using UserService.Application.Users.Queries.GetUser;
using UserService.WebApi.Features.Users.CreateUser;
using UserService.WebApi.Features.Users.DeleteUser;
using UserService.WebApi.Features.Users.GetUser;
using UserService.WebApi.Features.Users.UpdateUser;


namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public static class UsuariosController
    {

        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/User", GetAllUsers);
            app.MapGet("/User/{id}", GetUser);
            app.MapPost("/User", CreateUser);
            app.MapPut("/User", UpdateUser);
            app.MapDelete("/User/{id}", DeleteUser);

        }

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet]
        private static async Task<IResult> GetAllUsers(IMediator mediator, CancellationToken cancellationToken)
        {
            try
            {
                GetAllUsersResult products = await mediator.Send(new GetAllUsersQuerie(), cancellationToken);

                return Results.Ok(products);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet("{id}")]
        private static async Task<IResult> GetUser(int id, IMediator mediator, IMapper mapper, CancellationToken cancellationToken)
        {
            try
            {
                GetUserRequest request = new GetUserRequest { Id = id };

                GetUserQuerie querie = mapper.Map<GetUserQuerie>(request.Id);
                GetUserResult result = await mediator.Send(querie, cancellationToken);

                if (result == null) return Results.NotFound();

                return Results.Ok(mapper.Map<GetUserResponse>(result));
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        private static async Task<IResult> CreateUser(CreateUserRequest user, IMediator mediator, IMapper mapper, CancellationToken cancellationToken)
        {
            try
            {
                CreateUserCommand command = mapper.Map<CreateUserCommand>(user);

                CreateUserResult result = await mediator.Send(command, cancellationToken);

                if (result == null) return Results.BadRequest();

                return Results.Ok(mapper.Map<GetUserResponse>(result));
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPut]
        private static async Task<IResult> UpdateUser(UpdateUserRequest user, IMediator mediator, IMapper mapper, CancellationToken cancellationToken)
        {
            try
            {
                UpdateUserCommand command = mapper.Map<UpdateUserCommand>(user);

                UpdateUserResult? result = await mediator.Send(command, cancellationToken);

                if (result == null) return Results.BadRequest();

                return Results.Ok(mapper.Map<UpdateUserResponse>(result));
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete]
        private static async Task<IResult> DeleteUser(int id, IMediator mediator, IMapper mapper, CancellationToken cancellationToken)
        {
            try
            {
                DeleteUserRequest request = new DeleteUserRequest { Id = id };
                DeleteUserCommand command = mapper.Map<DeleteUserCommand>(request.Id);

                await mediator.Send(command, cancellationToken);

                return Results.Ok("The user was successfully deleted!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

    }
}
