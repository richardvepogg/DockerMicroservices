using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Application.Users.Queries
{
    public class GetUserResult
    {
        public int id { get; set; }

        public string name { get; set; }

        public string password { get; set; }

              public UserRole role { get; set; }
        public string token { get; set; }
    }
}
