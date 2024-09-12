using Dotnetstore.Intranet.WebAPI.Organization.UserGroups;
using Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;
using Dotnetstore.Intranet.WebAPI.Organization.UserRoles;
using Dotnetstore.Intranet.WebAPI.Organization.UserRolesInUserGroups;
using Dotnetstore.Intranet.WebAPI.Organization.Users;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserRoles;

public class UserRoleTests
{
    [Fact]
    public void Properties_SetAndGet_ReturnsCorrectValues()
    {
        // Arrange
        var userRoleId = new UserRoleId(Guid.NewGuid());
        var userRole = new UserRole
        {
            UserRoleId = userRoleId,
            Name = "Test Role",
            UserRoleInUserGroups = new List<UserRoleInUserGroup>(),
            UserInUserRoles = new List<UserInUserRole>()
        };

        // Act & Assert
        using (new AssertionScope())
        {
            userRole.UserRoleId.Should().Be(userRoleId);
            userRole.Name.Should().Be("Test Role");
            userRole.UserRoleInUserGroups.Should().BeEmpty();
            userRole.UserInUserRoles.Should().BeEmpty();
        }
    }

    [Fact]
    public void AddUserRoleInUserGroup_AddsCorrectly()
    {
        // Arrange
        var userRole = new UserRole
        {
            UserRoleId = new UserRoleId(Guid.NewGuid()),
            Name = "Test Role"
        };
        var userRoleInUserGroup = new UserRoleInUserGroup
        {
            UserRoleId = userRole.UserRoleId,
            UserGroupId = new UserGroupId(Guid.NewGuid())
        };

        // Act
        userRole.UserRoleInUserGroups.Add(userRoleInUserGroup);

        // Assert
        using (new AssertionScope())
        {
            userRole.UserRoleInUserGroups.Should().ContainSingle();
            userRole.UserRoleInUserGroups.Should().Contain(userRoleInUserGroup);
        }
    }

    [Fact]
    public void AddUserInUserRole_AddsCorrectly()
    {
        // Arrange
        var userRole = new UserRole
        {
            UserRoleId = new UserRoleId(Guid.NewGuid()),
            Name = "Test Role"
        };
        var userInUserRole = new UserInUserRole
        {
            Id = new UserInUserRoleId(Guid.NewGuid()),
            UserId = new UserId(Guid.NewGuid()),
            UserRoleId = userRole.UserRoleId
        };

        // Act
        userRole.UserInUserRoles.Add(userInUserRole);

        // Assert
        using (new AssertionScope())
        {
            userRole.UserInUserRoles.Should().ContainSingle();
            userRole.UserInUserRoles.Should().Contain(userInUserRole);
        }
    }
}