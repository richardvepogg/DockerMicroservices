using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Users.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResult>
    {
        public int id { get; set; }
        public string name { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}
