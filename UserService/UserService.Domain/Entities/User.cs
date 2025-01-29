using System.ComponentModel.DataAnnotations;
using UserService.Domain.Enums;
using UserService.Domain.ValueObjects;


namespace UserService.Domain.Entities
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
