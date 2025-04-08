using UserService.Domain.Enums;
using UserService.Domain.ValueObjects;

namespace UserService.WebApi.Features.Users.GetAllUsers
{
    public class GetAllUsersResponse
    {
        public IEnumerable<GetAllUserResponse>? GetAllUsersResponses { get; set; }
        public class GetAllUserResponse
        {
            public string id { get; set; }
            public string name { get; set; }
            public ContactInfo Contact { get; set; }
            public string password { get; set; }
            public UserRole role { get; set; }
        }
    }
}
