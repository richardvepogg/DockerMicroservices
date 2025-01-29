using AuthenticationService.Domain.Enums;
using AuthenticationService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Application.Users.Queries
{
    public class GetUserResult
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ContactInfo Contact { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public string token { get; set; }
    }
}
