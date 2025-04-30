using UserService.Domain.Enums;
using UserService.Domain.ValueObjects;

namespace UserService.WebApi.Features.Users.CreateUser
{
    public class CreateUserResponse
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public ContactInfo? Contact { get; set; }
        public string password { get; set; } = string.Empty;
        public UserRole role { get; set; }
    }
}
