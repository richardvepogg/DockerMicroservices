using AuthenticationService.Domain.Enums;

namespace AuthenticationService.WebApi.Features.Users.GetUser
{
    public class GetUserResponse
    {
        public int id { get; set; }

        public string name { get; set; }

        public string password { get; set; }

        public UserRole role { get; set; }
        
        public string token { get; set; }
    }
}
