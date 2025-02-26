using FluentValidation.TestHelper;
using UserService.Domain.Validators;
using UserService.Unit.Domain.Entities.TestData;

namespace UserService.Unit.Domain.Validation
{
    public class UserValidatorTests
    {
        private readonly UserValidator _validator;

        public UserValidatorTests()
        {
            _validator = new UserValidator();
        }


        [Fact(DisplayName = "Valid user should pass all validation rules")]
        public void Given_ValidUser_When_Validated_Then_ShouldNotHaveErrors()
        {
            // Arrange
            var user = UserTestData.GenerateValidUser();

            // Act
            var result = _validator.TestValidate(user);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }


        [Theory(DisplayName = "Invalid username formats should fail validation")]
        [InlineData("")] // Empty
        [InlineData("ab")] // Less than 3 characters
        public void Given_InvalidUsername_When_Validated_Then_ShouldHaveError(string username)
        {
            // Arrange
            var user = UserTestData.GenerateValidUser();
            user.Name = username;

            // Act
            var result = _validator.TestValidate(user);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }


        [Fact(DisplayName = "Username longer than maximum length should fail validation")]
        public void Given_UsernameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var user = UserTestData.GenerateValidUser();
            user.Name = UserTestData.GenerateLongUsername();

            // Act
            var result = _validator.TestValidate(user);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }


        [Fact(DisplayName = "Invalid password formats should fail validation")]
        public void Given_InvalidPassword_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var user = UserTestData.GenerateValidUser();
            user.Password = UserTestData.GenerateInvalidPassword();

            // Act
            var result = _validator.TestValidate(user);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }


        [Fact(DisplayName = "Invalid phone formats should fail validation")]
        public void Given_InvalidPhone_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var user = UserTestData.GenerateValidUser();


            user.UpdateContactInfo(new UserService.Domain.ValueObjects.ContactInfo("", UserTestData.GenerateValidPhone()));

            // Act
            var result = _validator.TestValidate(user);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.contactInfo.Phone);
        }


    }

}
