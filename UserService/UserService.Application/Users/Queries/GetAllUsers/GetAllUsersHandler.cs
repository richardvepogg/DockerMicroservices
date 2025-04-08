using AutoMapper;
using MediatR;
using UserService.Application.Users.Queries.GetAllUsers;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuerie, GetAllUsersResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetAllUsersResult> Handle(GetAllUsersQuerie request, CancellationToken cancellationToken)
    {
        // Obtém os usuários do repositório
        IEnumerable<User> users = await _userRepository.GetAllAsync(cancellationToken);

        // Lança exceção se nenhum usuário for encontrado
        if (users == null || !users.Any())
        {
            throw new KeyNotFoundException("No users found.");
        }

        // Retorna os resultados mapeados encapsulados no GetAllUsersResult
        return new GetAllUsersResult
        {
            GetAllUsersResults = _mapper.Map<IEnumerable<GetAllUsersResult.GetAllUserResult>>(users)
        };
    }
}
