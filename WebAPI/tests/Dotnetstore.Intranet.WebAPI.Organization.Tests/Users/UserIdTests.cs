using Dotnetstore.Intranet.WebAPI.Organization.Users;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.Users;

public class UserIdTests
{
    [Fact]
    public void Value_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var userId = new UserId(guid);

        // Act & Assert
        userId.Value.Should().Be(guid);
    }

    [Fact]
    public void EqualityOperator_SameValue_ReturnsTrue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var userId1 = new UserId(guid);
        var userId2 = new UserId(guid);

        // Act & Assert
        (userId1 == userId2).Should().BeTrue();
    }

    [Fact]
    public void EqualityOperator_DifferentValue_ReturnsFalse()
    {
        // Arrange
        var userId1 = new UserId(Guid.NewGuid());
        var userId2 = new UserId(Guid.NewGuid());

        // Act & Assert
        (userId1 != userId2).Should().BeTrue();
    }

    [Fact]
    public void Equals_SameValue_ReturnsTrue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var userId1 = new UserId(guid);
        var userId2 = new UserId(guid);

        // Act & Assert
        userId1.Equals(userId2).Should().BeTrue();
    }

    [Fact]
    public void Equals_DifferentValue_ReturnsFalse()
    {
        // Arrange
        var userId1 = new UserId(Guid.NewGuid());
        var userId2 = new UserId(Guid.NewGuid());

        // Act & Assert
        userId1.Equals(userId2).Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_SameValue_ReturnsSameHashCode()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var userId1 = new UserId(guid);
        var userId2 = new UserId(guid);

        // Act & Assert
        userId1.GetHashCode().Should().Be(userId2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentValue_ReturnsDifferentHashCode()
    {
        // Arrange
        var userId1 = new UserId(Guid.NewGuid());
        var userId2 = new UserId(Guid.NewGuid());

        // Act & Assert
        userId1.GetHashCode().Should().NotBe(userId2.GetHashCode());
    }
}