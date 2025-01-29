using UserService.Domain.Enums;

namespace UserService.WebApi.Features.Users.GetAllUsers
{
    public class GetAllUsersResponse
    {
        IEnumerable<GetAllUserResponse>? getAllUserResponse { get; set; }
        private class GetAllUserResponse
        {
            public string id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string password { get; set; }
            public UserRole role { get; set; }
        }
    }
}
