using MediatR;


namespace UserService.Application.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuerie : IRequest<GetAllUsersResult>
    {
    }
}
