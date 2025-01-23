using MediatR;


namespace AuthenticationService.Application.Users.Queries
{
    public record GetUserQuerie : IRequest<GetUserResult>
    {
        public string name { get; set; }

        public string password { get; set; }
    }
}
