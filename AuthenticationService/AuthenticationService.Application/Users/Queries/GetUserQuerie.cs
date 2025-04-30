using MediatR;


namespace AuthenticationService.Application.Users.Queries
{
    public record GetUserQuerie : IRequest<GetUserResult>
    {
        public string name { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;
    }
}
