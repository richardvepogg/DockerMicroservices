using System.ComponentModel.DataAnnotations;
using UserService.Domain.Common;
using UserService.Domain.Enums;
using UserService.Domain.Validators;
using UserService.Domain.ValueObjects;


namespace UserService.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ContactInfo contactInfo { get; private set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public User() { }
        public User(int id, string name, ContactInfo contact, string password, UserRole role)
        {
            Id = id;
            Name = name;
            contactInfo = contact;
            Password = password;
            Role = role;
        }

        public void UpdateContactInfo(ContactInfo contact)
        {
            contactInfo = contact;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new UserValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }

}
