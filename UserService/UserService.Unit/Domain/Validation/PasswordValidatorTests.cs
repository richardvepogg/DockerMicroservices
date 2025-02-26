using FluentValidation.TestHelper;
using UserService.Domain.Validation;
using UserService.Unit.Domain.Entities.TestData;


namespace UserService.Unit.Domain.Validation;


public class PasswordValidatorTests
{
    private readonly PasswordValidator _validator;

    public PasswordValidatorTests()
    {
        _validator = new PasswordValidator();
    }

    [Fact(DisplayName = "Valid passwords should pass validation")]
    public void Given_ValidPassword_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var password = UserTestData.GenerateValidPassword();

        // Act
        var result = _validator.TestValidate(password);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Empty password should fail validation")]
    public void Given_EmptyPassword_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var password = string.Empty;

        // Act
        var result = _validator.TestValidate(password);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x);
    }

    [Theory(DisplayName = "Password shorter than minimum length should fail validation")]
    [InlineData("Test@1")] // 6 characters
    [InlineData("Pass#2")] // 7 characters
    public void Given_PasswordShorterThanMinimum_When_Validated_Then_ShouldHaveError(string password)
    {
        // Act
        var result = _validator.TestValidate(password);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x);
    }

    [Fact(DisplayName = "Password without uppercase should fail validation")]
    public void Given_PasswordWithoutUppercase_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var password = "password@123";

        // Act
        var result = _validator.TestValidate(password);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Password must contain at least one uppercase letter.");
    }

    [Fact(DisplayName = "Password without lowercase should fail validation")]
    public void Given_PasswordWithoutLowercase_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var password = "PASSWORD@123";

        // Act
        var result = _validator.TestValidate(password);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Password must contain at least one lowercase letter.");
    }

    [Fact(DisplayName = "Password without numbers should fail validation")]
    public void Given_PasswordWithoutNumber_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var password = "Password@ABC";

        // Act
        var result = _validator.TestValidate(password);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Password must contain at least one number.");
    }

    [Fact(DisplayName = "Password without special characters should fail validation")]
    public void Given_PasswordWithoutSpecialCharacter_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var password = "Password123";

        // Act
        var result = _validator.TestValidate(password);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Password must contain at least one special character.");
    }
}
