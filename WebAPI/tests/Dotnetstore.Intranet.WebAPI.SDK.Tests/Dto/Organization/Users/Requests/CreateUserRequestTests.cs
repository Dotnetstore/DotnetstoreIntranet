using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Requests;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.SDK.Tests.Dto.Organization.Users.Requests;

public class CreateUserRequestTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        const string lastName = "Doe";
        const string firstName = "John";
        const string middleName = "A";
        const string englishName = "Johnny";
        const string ssn = "123-45-6789";
        var dob = new DateTime(1990, 1, 1);
        const bool isMale = true;
        const bool lastNameFirst = false;
        const string username = "johndoe";
        const string password = "password123";
        const string confirmPassword = "password123";

        // Act
        var request = new CreateUserRequest(
            lastName,
            firstName,
            middleName,
            englishName,
            ssn,
            dob,
            isMale,
            lastNameFirst,
            username,
            password,
            confirmPassword
        );

        // Assert
        using (new AssertionScope())
        {
            request.LastName.Should().Be(lastName);
            request.FirstName.Should().Be(firstName);
            request.MiddleName.Should().Be(middleName);
            request.EnglishName.Should().Be(englishName);
            request.SocialSecurityNumber.Should().Be(ssn);
            request.DateOfBirth.Should().Be(dob);
            request.IsMale.Should().Be(isMale);
            request.LastNameFirst.Should().Be(lastNameFirst);
            request.Username.Should().Be(username);
            request.Password.Should().Be(password);
            request.ConfirmPassword.Should().Be(confirmPassword);
        }
    }

    [Fact]
    public void Constructor_AllowsNullValues()
    {
        // Arrange
        const string lastName = "Doe";
        const string firstName = "John";
        string? middleName = null;
        string? englishName = null;
        string? ssn = null;
        DateTime? dob = null;
        const bool isMale = true;
        const bool lastNameFirst = false;
        const string username = "johndoe";
        const string password = "password123";
        const string confirmPassword = "password123";

        // Act
        var request = new CreateUserRequest(
            lastName,
            firstName,
            middleName,
            englishName,
            ssn,
            dob,
            isMale,
            lastNameFirst,
            username,
            password,
            confirmPassword
        );

        // Assert
        using (new AssertionScope())
        {
            request.LastName.Should().Be(lastName);
            request.FirstName.Should().Be(firstName);
            request.MiddleName.Should().BeNull();
            request.EnglishName.Should().BeNull();
            request.SocialSecurityNumber.Should().BeNull();
            request.DateOfBirth.Should().BeNull();
            request.IsMale.Should().Be(isMale);
            request.LastNameFirst.Should().Be(lastNameFirst);
            request.Username.Should().Be(username);
            request.Password.Should().Be(password);
            request.ConfirmPassword.Should().Be(confirmPassword);
        }
    }
}