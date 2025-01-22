using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Users.Command.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResult>
    {

        public string name { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}
