using System;
using System.Collections.Generic;


namespace UserService.Domain.ValueObjects
{
    public class UserVO
    {
        public int id { get; set; }

        public string name { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}
