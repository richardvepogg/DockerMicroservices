using UserService.Domain.Enums;
using UserService.Domain.ValueObjects;

namespace UserService.Application.Users.Queries.GetUser
{
    public class GetUserResult
    {
        public int id { get; set; }

        public string name { get; set; } = string.Empty;
        public ContactInfo? Contact { get; set; }
        public string password { get; set; } = string.Empty;
        public UserRole role { get; set; }
    }
}
