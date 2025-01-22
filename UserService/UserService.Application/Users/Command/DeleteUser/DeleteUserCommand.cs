
using MediatR;

namespace UserService.Application.Users.Command.DeleteUser
{
    public record DeleteUserCommand : IRequest<DeleteUserResult>
    {

        public long Id { get; }


        public DeleteUserCommand(long id)
        {
            Id = id;
        }
    }
}
