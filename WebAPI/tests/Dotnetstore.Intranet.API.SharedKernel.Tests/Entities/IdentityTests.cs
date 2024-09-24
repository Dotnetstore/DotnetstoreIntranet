using Dotnetstore.Intranet.API.SharedKernel.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Intranet.API.SharedKernel.Tests.Entities;

public class IdentityTests
{
    private class TestIdentity : Identity;

    [Fact]
    public void Properties_SetAndGet_ReturnsCorrectValues()
    {
        // Arrange
        var identity = new TestIdentity();
        const string username = "johndoe";
        const string password = "password123";
        const string salt1 = "salt1";
        const string salt2 = "salt2";
        const string salt3 = "salt3";
        const string salt4 = "salt4";
        const bool isBlocked = true;
        var blockedDate = DateTimeOffset.UtcNow;

        // Act
        identity.Username = username;
        identity.Password = password;
        identity.Salt1 = salt1;
        identity.Salt2 = salt2;
        identity.Salt3 = salt3;
        identity.Salt4 = salt4;
        identity.IsBlocked = isBlocked;
        identity.BlockedDate = blockedDate;

        // Assert
        using (new AssertionScope())
        {
            identity.Username.Should().Be(username);
            identity.Password.Should().Be(password);
            identity.Salt1.Should().Be(salt1);
            identity.Salt2.Should().Be(salt2);
            identity.Salt3.Should().Be(salt3);
            identity.Salt4.Should().Be(salt4);
            identity.IsBlocked.Should().Be(isBlocked);
            identity.BlockedDate.Should().Be(blockedDate);
        }
    }

    [Fact]
    public void ToString_ReturnsCorrectFormattedString()
    {
        // Arrange
        var identity = new TestIdentity
        {
            LastName = "Doe",
            FirstName = "John",
            MiddleName = "A.",
            EnglishName = "Johnny",
            LastNameFirst = true
        };

        // Act
        var result = identity.ToString();

        // Assert
        result.Should().Be("Doe, John A. (Johnny)");

        // Arrange
        identity.LastNameFirst = false;

        // Act
        result = identity.ToString();

        // Assert
        result.Should().Be("John A. Doe (Johnny)");
    }
}