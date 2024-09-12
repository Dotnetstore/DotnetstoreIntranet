using Dotnetstore.Intranet.WebAPI.Organization.Data;
using Dotnetstore.Intranet.WebAPI.Organization.UserRolesInUserGroups;
using Dotnetstore.Intranet.WebAPI.TestHelper.Data;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserRolesInUserGroups;

public class UserRoleInUserGroupConfigurationTests
{
    [Fact]
    public void UserRoleInUserGroupId_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserRoleInUserGroup));
        var userRoleInUserGroupIdProperty = entityType!.FindProperty(nameof(UserRoleInUserGroup.UserRoleInUserGroupId));

        // Assert
        using (new AssertionScope())
        {
            userRoleInUserGroupIdProperty.Should().NotBeNull();
            userRoleInUserGroupIdProperty!.IsPrimaryKey().Should().BeTrue();
            userRoleInUserGroupIdProperty.IsNullable.Should().BeFalse();
            userRoleInUserGroupIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }

    [Fact]
    public void UserGroupId_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserRoleInUserGroup));
        var userGroupIdProperty = entityType!.FindProperty(nameof(UserRoleInUserGroup.UserGroupId));

        // Assert
        using (new AssertionScope())
        {
            userGroupIdProperty.Should().NotBeNull();
            userGroupIdProperty!.IsNullable.Should().BeFalse();
            userGroupIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }

    [Fact]
    public void UserRoleId_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserRoleInUserGroup));
        var userRoleIdProperty = entityType!.FindProperty(nameof(UserRoleInUserGroup.UserRoleId));

        // Assert
        using (new AssertionScope())
        {
            userRoleIdProperty.Should().NotBeNull();
            userRoleIdProperty!.IsNullable.Should().BeFalse();
            userRoleIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }

    [Fact]
    public void Indexes_AreConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserRoleInUserGroup));
        var indexes = entityType!.GetIndexes();

        // Assert
        using (new AssertionScope())
        {
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserRoleInUserGroup.UserRoleInUserGroupId)) && i.IsUnique);
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserRoleInUserGroup.IsDeleted)));
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserRoleInUserGroup.UserRoleId) && i.Properties.Any(p => p.Name == nameof(UserRoleInUserGroup.UserGroupId))));
        }
    }
}