using Dotnetstore.Intranet.WebAPI.Organization.EmailVerificationTokens;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.EmailVerificationTokens;

public class EmailVerificationTokenIdTests
{
    [Fact]
    public void Constructor_SetsIdCorrectly()
    {
        // Arrange
        var guid = Guid.NewGuid();

        // Act
        var emailVerificationTokenId = new EmailVerificationTokenId(guid);

        // Assert
        using (new AssertionScope())
        {
            emailVerificationTokenId.Value.Should().Be(guid);
        }
    }

    [Fact]
    public void Equals_ReturnsTrueForSameId()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var emailVerificationTokenId1 = new EmailVerificationTokenId(guid);
        var emailVerificationTokenId2 = new EmailVerificationTokenId(guid);

        // Act & Assert
        using (new AssertionScope())
        {
            emailVerificationTokenId1.Equals(emailVerificationTokenId2).Should().BeTrue();
        }
    }

    [Fact]
    public void Equals_ReturnsFalseForDifferentId()
    {
        // Arrange
        var emailVerificationTokenId1 = new EmailVerificationTokenId(Guid.NewGuid());
        var emailVerificationTokenId2 = new EmailVerificationTokenId(Guid.NewGuid());

        // Act & Assert
        using (new AssertionScope())
        {
            emailVerificationTokenId1.Equals(emailVerificationTokenId2).Should().BeFalse();
        }
    }

    [Fact]
    public void GetHashCode_ReturnsSameHashCodeForSameId()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var emailVerificationTokenId1 = new EmailVerificationTokenId(guid);
        var emailVerificationTokenId2 = new EmailVerificationTokenId(guid);

        // Act & Assert
        using (new AssertionScope())
        {
            emailVerificationTokenId1.GetHashCode().Should().Be(emailVerificationTokenId2.GetHashCode());
        }
    }

    [Fact]
    public void GetHashCode_ReturnsDifferentHashCodeForDifferentId()
    {
        // Arrange
        var emailVerificationTokenId1 = new EmailVerificationTokenId(Guid.NewGuid());
        var emailVerificationTokenId2 = new EmailVerificationTokenId(Guid.NewGuid());

        // Act & Assert
        using (new AssertionScope())
        {
            emailVerificationTokenId1.GetHashCode().Should().NotBe(emailVerificationTokenId2.GetHashCode());
        }
    }
}