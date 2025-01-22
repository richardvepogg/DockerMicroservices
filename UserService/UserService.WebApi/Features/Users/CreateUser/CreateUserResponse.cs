namespace UserService.WebApi.Features.Users.CreateUser
{
    public class CreateUserResponse
    {
        public int id { get; set; }
        public string name { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}
