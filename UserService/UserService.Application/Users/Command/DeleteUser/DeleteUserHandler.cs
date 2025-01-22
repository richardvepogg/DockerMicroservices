using MediatR;
using UserService.Domain.Interfaces;

namespace UserService.Application.Users.Command.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResult>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteUserResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var success = await _userRepository.RemoveAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"User with ID {request.Id} not found");

            return new DeleteUserResult { Success = true };
        }
    }
}
