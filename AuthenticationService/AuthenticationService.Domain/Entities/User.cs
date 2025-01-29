using AuthenticationService.Domain.Enums;
using AuthenticationService.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ContactInfo Contact { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
