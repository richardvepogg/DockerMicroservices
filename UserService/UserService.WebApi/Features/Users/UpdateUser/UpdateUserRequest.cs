using UserService.Domain.Enums;
using UserService.Domain.ValueObjects;

namespace UserService.WebApi.Features.Users.UpdateUser
{
    public class UpdateUserRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public ContactInfo Contact { get; set; }
        public string password { get; set; }
        public UserRole role { get; set; }
    }
}
