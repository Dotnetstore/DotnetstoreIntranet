using Dotnetstore.Intranet.WebAPI.Organization.UserGroups;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserGroups;

public class UserGroupIdTests
{
    [Fact]
    public void Constructor_SetsIdCorrectly()
    {
        // Arrange
        var guid = Guid.NewGuid();

        // Act
        var userGroupId = new UserGroupId(guid);

        // Assert
        using (new AssertionScope())
        {
            userGroupId.Value.Should().Be(guid);
        }
    }

    [Fact]
    public void Equals_ReturnsTrueForSameId()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var userGroupId1 = new UserGroupId(guid);
        var userGroupId2 = new UserGroupId(guid);

        // Act & Assert
        using (new AssertionScope())
        {
            userGroupId1.Equals(userGroupId2).Should().BeTrue();
        }
    }

    [Fact]
    public void Equals_ReturnsFalseForDifferentId()
    {
        // Arrange
        var userGroupId1 = new UserGroupId(Guid.NewGuid());
        var userGroupId2 = new UserGroupId(Guid.NewGuid());

        // Act & Assert
        using (new AssertionScope())
        {
            userGroupId1.Equals(userGroupId2).Should().BeFalse();
        }
    }

    [Fact]
    public void GetHashCode_ReturnsSameHashCodeForSameId()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var userGroupId1 = new UserGroupId(guid);
        var userGroupId2 = new UserGroupId(guid);

        // Act & Assert
        using (new AssertionScope())
        {
            userGroupId1.GetHashCode().Should().Be(userGroupId2.GetHashCode());
        }
    }

    [Fact]
    public void GetHashCode_ReturnsDifferentHashCodeForDifferentId()
    {
        // Arrange
        var userGroupId1 = new UserGroupId(Guid.NewGuid());
        var userGroupId2 = new UserGroupId(Guid.NewGuid());

        // Act & Assert
        using (new AssertionScope())
        {
            userGroupId1.GetHashCode().Should().NotBe(userGroupId2.GetHashCode());
        }
    }
}