namespace UserService.WebApi.Features.Users.CreateUser
{
    public class CreateUserRequest
    {
        public string name { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}
