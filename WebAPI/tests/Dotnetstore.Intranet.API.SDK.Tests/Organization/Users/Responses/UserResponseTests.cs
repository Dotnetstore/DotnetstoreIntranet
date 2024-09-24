using Dotnetstore.Intranet.API.SDK.Organization.Users.Responses;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.API.SDK.Tests.Organization.Users.Responses;

public class UserResponseTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        const string lastName = "Doe";
        const string firstName = "John";
        const string middleName = "A";
        const string englishName = "Johnny";
        const string ssn = "123-45-6789";
        var dob = new DateTime(1990, 1, 1);
        const bool isMale = true;
        const bool lastNameFirst = false;
        const bool isBlocked = false;
        const bool isDeleted = false;
        var userGroups = new List<string> { "Group1", "Group2" };
        var userRoles = new List<string> { "Role1", "Role2" };
        var userEmails = new List<string> { "john.doe@example.com" };

        // Act
        var response = new UserResponse(
            id,
            lastName,
            firstName,
            middleName,
            englishName,
            ssn,
            dob,
            isMale,
            lastNameFirst,
            isBlocked,
            isDeleted,
            userGroups,
            userRoles,
            userEmails
        );

        // Assert
        response.Id.Should().Be(id);
        response.LastName.Should().Be(lastName);
        response.FirstName.Should().Be(firstName);
        response.MiddleName.Should().Be(middleName);
        response.EnglishName.Should().Be(englishName);
        response.SocialSecurityNumber.Should().Be(ssn);
        response.DateOfBirth.Should().Be(dob);
        response.IsMale.Should().Be(isMale);
        response.LastNameFirst.Should().Be(lastNameFirst);
        response.IsBlocked.Should().Be(isBlocked);
        response.IsDeleted.Should().Be(isDeleted);
        response.UserGroups.Should().BeEquivalentTo(userGroups);
        response.UserRoles.Should().BeEquivalentTo(userRoles);
        response.UserEmails.Should().BeEquivalentTo(userEmails);
    }

    [Fact]
    public void Constructor_AllowsNullValues()
    {
        // Arrange
        var id = Guid.NewGuid();
        const string lastName = "Doe";
        const string firstName = "John";
        string? middleName = null;
        string? englishName = null;
        string? ssn = null;
        DateTime? dob = null;
        const bool isMale = true;
        const bool lastNameFirst = false;
        const bool isBlocked = false;
        const bool isDeleted = false;
        var userGroups = new List<string> { "Group1", "Group2" };
        var userRoles = new List<string> { "Role1", "Role2" };
        var userEmails = new List<string> { "john.doe@example.com" };

        // Act
        var response = new UserResponse(
            id,
            lastName,
            firstName,
            middleName,
            englishName,
            ssn,
            dob,
            isMale,
            lastNameFirst,
            isBlocked,
            isDeleted,
            userGroups,
            userRoles,
            userEmails
        );

        // Assert
        response.Id.Should().Be(id);
        response.LastName.Should().Be(lastName);
        response.FirstName.Should().Be(firstName);
        response.MiddleName.Should().BeNull();
        response.EnglishName.Should().BeNull();
        response.SocialSecurityNumber.Should().BeNull();
        response.DateOfBirth.Should().BeNull();
        response.IsMale.Should().Be(isMale);
        response.LastNameFirst.Should().Be(lastNameFirst);
        response.IsBlocked.Should().Be(isBlocked);
        response.IsDeleted.Should().Be(isDeleted);
        response.UserGroups.Should().BeEquivalentTo(userGroups);
        response.UserRoles.Should().BeEquivalentTo(userRoles);
        response.UserEmails.Should().BeEquivalentTo(userEmails);
    }
}