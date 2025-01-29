using UserService.Domain.Enums;

namespace UserService.Application.Users.Queries.GetUser
{
    public class GetUserResult
    {
        public int id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public UserRole role { get; set; }
    }
}
