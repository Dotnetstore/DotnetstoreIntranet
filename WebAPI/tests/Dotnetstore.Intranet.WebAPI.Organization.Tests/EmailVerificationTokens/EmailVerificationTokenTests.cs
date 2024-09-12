using Dotnetstore.Intranet.WebAPI.Organization.EmailVerificationTokens;
using Dotnetstore.Intranet.WebAPI.Organization.Users;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.EmailVerificationTokens;

public class EmailVerificationTokenTests
{
    [Fact]
    public void Properties_SetAndGet_ReturnsCorrectValues()
    {
        // Arrange
        var tokenId = new EmailVerificationTokenId(Guid.NewGuid());
        var userId = new UserId(Guid.NewGuid());
        var expireDate = DateTime.UtcNow.AddDays(1);
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
        var token = new EmailVerificationToken
        {
            Id = tokenId,
            UserId = userId,
            ExpireDate = expireDate,
            User = user
        };

        // Act & Assert
        token.Id.Should().Be(tokenId);
        token.UserId.Should().Be(userId);
        token.ExpireDate.Should().Be(expireDate);
        token.User.Should().Be(user);
    }
}