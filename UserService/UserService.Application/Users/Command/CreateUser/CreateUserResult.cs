namespace UserService.Application.Users.Command.CreateUser
{
    public class CreateUserResult
    {
        public int id { get; set; }

        public string name { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}
