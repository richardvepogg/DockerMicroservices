using Bogus;
using UserService.Domain.Entities;
using UserService.Domain.Enums;

namespace UserService.Unit.Domain.Entities.TestData
{
    public static class UserTestData
    {

        private static readonly Faker<User> UserFaker = new Faker<User>()
            .RuleFor(u => u.Name, f => f.Internet.UserName())
            .RuleFor(u => u.Password, f => $"Test@{f.Random.Number(100, 999)}")
            .RuleFor(u => u.contactInfo.Phone, f => $"+55{f.Random.Number(11, 99)}{f.Random.Number(100000000, 999999999)}")
            .RuleFor(u => u.Role, f => f.PickRandom(UserRole.Manager, UserRole.Employe));


        public static User GenerateValidUser()
        {
            return UserFaker.Generate();
        }

     
        public static string GenerateValidPassword()
        {
            return $"Test@{new Faker().Random.Number(100, 999)}";
        }


        public static string GenerateValidPhone()
        {
            var faker = new Faker();
            return $"+55{faker.Random.Number(11, 99)}{faker.Random.Number(100000000, 999999999)}";
        }


        public static string GenerateValidUsername()
        {
            return new Faker().Internet.UserName();
        }


        public static string GenerateInvalidPassword()
        {
            return new Faker().Lorem.Word();
        }

        public static string GenerateInvalidPhone()
        {
            return new Faker().Random.AlphaNumeric(5);
        }


        public static string GenerateLongUsername()
        {
            return new Faker().Random.String2(51);
        }
    }

}
