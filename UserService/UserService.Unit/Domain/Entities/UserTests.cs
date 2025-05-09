﻿using UserService.Domain.Enums;
using UserService.Unit.Domain.Entities.TestData;

namespace UserService.Unit.Domain.Entities
{
    public class UserTests
    {
        [Fact]
        public void GenerateValidUser_ShouldReturnUserWithValidProperties()
        {
            // Arrange
            var user = UserTestData.GenerateValidUser();

            // Assert
            Assert.NotNull(user);
            Assert.NotNull(user.Name);
            Assert.NotNull(user.Password);
            Assert.NotNull(user.contactInfo.Phone);
            Assert.StartsWith("Test@", user.Password);
            Assert.StartsWith("+55", user.contactInfo.Phone);
            Assert.True(user.contactInfo.Phone.Length == 15);
            Assert.True(user.Role == UserRole.Manager || user.Role == UserRole.Employe);
        }

        [Fact]
        public void GenerateValidPassword_ShouldReturnPasswordWithCorrectFormat()
        {
            // Arrange
            var password = UserTestData.GenerateValidPassword();

            // Assert
            Assert.NotNull(password);
            Assert.StartsWith("Test@", password);
            Assert.True(password.Length >= 7); // "Test@" + 3 digits
        }

        [Fact]
        public void GenerateValidPhone_ShouldReturnPhoneNumberWithCorrectFormat()
        {
            // Arrange
            var phone = UserTestData.GenerateValidPhone();

            // Assert
            Assert.NotNull(phone);
            Assert.StartsWith("+55", phone);
            Assert.True(phone.Length == 15);
        }

        [Fact]
        public void GenerateValidUsername_ShouldReturnNonEmptyUsername()
        {
            // Arrange
            var username = UserTestData.GenerateValidUsername();

            // Assert
            Assert.NotNull(username);
            Assert.NotEmpty(username);
        }

        [Fact]
        public void GenerateInvalidPassword_ShouldReturnWord()
        {
            // Arrange
            var password = UserTestData.GenerateInvalidPassword();

            // Assert
            Assert.NotNull(password);
            Assert.DoesNotContain("@", password);
            Assert.DoesNotContain("Test", password);
            Assert.True(password.Length > 0);
        }

        [Fact]
        public void GenerateInvalidPhone_ShouldReturnAlphaNumericString()
        {
            // Arrange
            var phone = UserTestData.GenerateInvalidPhone();

            // Assert
            Assert.NotNull(phone);
            Assert.False(phone.StartsWith("+55"));
            Assert.True(phone.Length == 5);
        }

        [Fact]
        public void GenerateLongUsername_ShouldReturnUsernameWithLength51()
        {
            // Arrange
            var username = UserTestData.GenerateLongUsername();

            // Assert
            Assert.NotNull(username);
            Assert.Equal(51, username.Length);
        }
    }

}
