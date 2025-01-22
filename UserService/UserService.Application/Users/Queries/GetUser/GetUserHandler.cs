using AutoMapper;
using MediatR;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Users.Queries.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserQuerie, GetUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserHandler(
        IUserRepository userRepository,
        IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserResult> Handle(GetUserQuerie request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.FindAsyncById(request.Id, cancellationToken);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {request.Id} not found");

            return _mapper.Map<GetUserResult>(user);
        }

    }
}
