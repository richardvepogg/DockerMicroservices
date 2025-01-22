

namespace UserService.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersResult
    {
        IEnumerable<GetAllUserResult>? getAllUsersResults { get; set; }
        private class GetAllUserResult
        {
            public int id { get; set; }
            public string name { get; set; }

            public string password { get; set; }

            public string role { get; set; }
        }
    }
}
