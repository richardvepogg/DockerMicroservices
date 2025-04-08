using AuthenticationService.Domain.Entities;
using AuthenticationService.Domain.Interfaces.Repositories;
using AuthenticationService.Domain.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace AuthenticationService.Application.Users.Queries
{
    public class GetUserHandler : IRequestHandler<GetUserQuerie, GetUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public GetUserHandler(
        IUserRepository userRepository,
        IMapper mapper,
        ITokenService tokenService
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<GetUserResult> Handle(GetUserQuerie request, CancellationToken cancellationToken)
        {
            User user =  _mapper.Map<User>(request);

            User? userFound = await _userRepository.FindAsync(user, cancellationToken);
            
            if (userFound == null)
                 throw new UserNotFoundException("User not found.");

            string token =  _tokenService.GenerateToken(userFound);

            GetUserResult result = _mapper.Map<GetUserResult>(userFound);
            result.token = token;

            return result;
        }

        public class UserNotFoundException : Exception
        {
            public UserNotFoundException() { }

            public UserNotFoundException(string message)
                : base(message) { }

            public UserNotFoundException(string message, Exception inner)
                : base(message, inner) { }
        }

    }
}
