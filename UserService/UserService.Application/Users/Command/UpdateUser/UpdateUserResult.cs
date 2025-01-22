namespace UserService.Application.Users.Command.UpdateUser
{
    public class UpdateUserResult
    {
        public int id { get; set; }
        public string name { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}
