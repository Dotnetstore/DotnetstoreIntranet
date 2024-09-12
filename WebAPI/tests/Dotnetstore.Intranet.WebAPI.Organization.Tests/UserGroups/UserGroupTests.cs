using Dotnetstore.Intranet.WebAPI.Organization.UserGroups;
using Dotnetstore.Intranet.WebAPI.Organization.UserInUserGroups;
using Dotnetstore.Intranet.WebAPI.Organization.UserRolesInUserGroups;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserGroups;

public class UserGroupTests
{
    [Fact]
    public void Properties_SetAndGet_ReturnsCorrectValues()
    {
        // Arrange
        var userGroupId = new UserGroupId(Guid.NewGuid());
        const string name = "Test Group";
        var userRoleInUserGroups = new List<UserRoleInUserGroup>();
        var userInUserGroups = new List<UserInUserGroup>();
        var userGroup = new UserGroup
        {
            UserGroupId = userGroupId,
            Name = name,
            UserRoleInUserGroups = userRoleInUserGroups,
            UserInUserGroups = userInUserGroups
        };

        // Act & Assert
        using (new AssertionScope())
        {
            userGroup.UserGroupId.Should().Be(userGroupId);
            userGroup.Name.Should().Be(name);
            userGroup.UserRoleInUserGroups.Should().BeSameAs(userRoleInUserGroups);
            userGroup.UserInUserGroups.Should().BeSameAs(userInUserGroups);
        }
    }
}