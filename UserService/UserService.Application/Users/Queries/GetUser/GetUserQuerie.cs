using MediatR;

namespace UserService.Application.Users.Queries.GetUser
{
    public record GetUserQuerie : IRequest<GetUserResult>
    {
        public int Id { get; }

        public GetUserQuerie(int id)
        {
            Id = id;
        }
    }
}
