
namespace AuthenticationService.Domain.ValueObjects
{
    public class ContactInfo
    {
        public string Email { get; }
        public string Phone { get; }

        public ContactInfo(string email, string phone)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }

    }

}
