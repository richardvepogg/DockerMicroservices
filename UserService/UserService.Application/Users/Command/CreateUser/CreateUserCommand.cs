using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Enums;
using UserService.Domain.ValueObjects;

namespace UserService.Application.Users.Command.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResult>
    {

        public string name { get; set; } = string.Empty;
        public ContactInfo? Contact { get; set; }
        public string password { get; set; } = string.Empty;
        public UserRole role { get; set; }
    }
}
