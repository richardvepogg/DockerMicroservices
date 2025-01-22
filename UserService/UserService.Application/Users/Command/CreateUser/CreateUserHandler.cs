using AutoMapper;
using MediatR;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Users.Command.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(command);

            User? createdUser = await _userRepository.AddAsync(user);
            CreateUserResult? result = _mapper.Map<CreateUserResult>(createdUser);
            return result;
        }


    }
}
