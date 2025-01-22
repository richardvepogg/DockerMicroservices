namespace UserService.WebApi.Features.Users.GetAllUsers
{
    public class GetAllUsersResponse
    {
        IEnumerable<GetAllUserResponse>? getAllUserResponse { get; set; }
        private class GetAllUserResponse
        {
            public string id { get; set; }
            public string name { get; set; }

            public string password { get; set; }

            public string role { get; set; }
        }
    }
}
