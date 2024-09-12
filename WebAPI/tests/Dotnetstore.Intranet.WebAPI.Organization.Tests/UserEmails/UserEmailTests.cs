using Dotnetstore.Intranet.WebAPI.Organization.Enums;
using Dotnetstore.Intranet.WebAPI.Organization.UserEmails;
using Dotnetstore.Intranet.WebAPI.Organization.Users;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserEmails;

public class UserEmailTests
{
    [Fact]
    public void Properties_SetAndGet_ReturnsCorrectValues()
    {
        // Arrange
        var userEmailId = new UserEmailId(Guid.NewGuid());
        var userId = new UserId(Guid.NewGuid());
        var emailType = EmailType.RegistrationEmail;
        const string emailAddress = "test@example.com";
        var user = new User
        {
            UserId = userId,
            Username = "TestUser",
            Password = "TestPassword",
            Salt1 = "Salt1",
            Salt2 = "Salt2",
            Salt3 = "Salt3",
            Salt4 = "Salt4",
            IsBlocked = false,
            BlockedDate = null
        };
        var userEmail = new UserEmail
        {
            UserEmailId = userEmailId,
            UserId = userId,
            EmailType = emailType,
            EmailAddress = emailAddress,
            User = user
        };

        // Act & Assert
        userEmail.UserEmailId.Should().Be(userEmailId);
        userEmail.UserId.Should().Be(userId);
        userEmail.EmailType.Should().Be(emailType);
        userEmail.EmailAddress.Should().Be(emailAddress);
        userEmail.User.Should().Be(user);
    }
}