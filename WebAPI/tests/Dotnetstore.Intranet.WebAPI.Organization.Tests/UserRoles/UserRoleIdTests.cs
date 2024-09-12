using Dotnetstore.Intranet.WebAPI.Organization.UserRoles;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserRoles;

public class UserRoleIdTests
{
    [Fact]
    public void Constructor_SetsIdCorrectly()
    {
        // Arrange
        var guid = Guid.NewGuid();

        // Act
        var userRoleId = new UserRoleId(guid);

        // Assert
        using (new AssertionScope())
        {
            userRoleId.Value.Should().Be(guid);
        }
    }

    [Fact]
    public void Equals_ReturnsTrueForSameId()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var userRoleId1 = new UserRoleId(guid);
        var userRoleId2 = new UserRoleId(guid);

        // Act & Assert
        using (new AssertionScope())
        {
            userRoleId1.Equals(userRoleId2).Should().BeTrue();
        }
    }

    [Fact]
    public void Equals_ReturnsFalseForDifferentId()
    {
        // Arrange
        var userRoleId1 = new UserRoleId(Guid.NewGuid());
        var userRoleId2 = new UserRoleId(Guid.NewGuid());

        // Act & Assert
        using (new AssertionScope())
        {
            userRoleId1.Equals(userRoleId2).Should().BeFalse();
        }
    }

    [Fact]
    public void GetHashCode_ReturnsSameHashCodeForSameId()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var userRoleId1 = new UserRoleId(guid);
        var userRoleId2 = new UserRoleId(guid);

        // Act & Assert
        using (new AssertionScope())
        {
            userRoleId1.GetHashCode().Should().Be(userRoleId2.GetHashCode());
        }
    }

    [Fact]
    public void GetHashCode_ReturnsDifferentHashCodeForDifferentId()
    {
        // Arrange
        var userRoleId1 = new UserRoleId(Guid.NewGuid());
        var userRoleId2 = new UserRoleId(Guid.NewGuid());

        // Act & Assert
        using (new AssertionScope())
        {
            userRoleId1.GetHashCode().Should().NotBe(userRoleId2.GetHashCode());
        }
    }
}