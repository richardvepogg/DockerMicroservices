using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Domain.Entities
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}
