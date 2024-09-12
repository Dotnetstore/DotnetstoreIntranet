using Dotnetstore.Intranet.WebAPI.Organization.Data;
using Dotnetstore.Intranet.WebAPI.Organization.UserInUserGroups;
using Dotnetstore.Intranet.WebAPI.TestHelper.Data;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserInUserGroups;

public class UserInUserGroupConfigurationTests
{
    [Fact]
    public void Id_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserInUserGroup));
        var idProperty = entityType!.FindProperty(nameof(UserInUserGroup.Id));

        // Assert
        using (new AssertionScope())
        {
            idProperty.Should().NotBeNull();
            idProperty!.IsPrimaryKey().Should().BeTrue();
            idProperty.IsNullable.Should().BeFalse();
            idProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }

    [Fact]
    public void UserId_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserInUserGroup));
        var userIdProperty = entityType!.FindProperty(nameof(UserInUserGroup.UserId));

        // Assert
        using (new AssertionScope())
        {
            userIdProperty.Should().NotBeNull();
            userIdProperty!.IsNullable.Should().BeFalse();
            userIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }

    [Fact]
    public void UserGroupId_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserInUserGroup));
        var userGroupIdProperty = entityType!.FindProperty(nameof(UserInUserGroup.UserGroupId));

        // Assert
        using (new AssertionScope())
        {
            userGroupIdProperty.Should().NotBeNull();
            userGroupIdProperty!.IsNullable.Should().BeFalse();
            userGroupIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }

    [Fact]
    public void Indexes_AreConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserInUserGroup));
        var indexes = entityType!.GetIndexes();

        // Assert
        using (new AssertionScope())
        {
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserInUserGroup.Id)));
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserInUserGroup.UserGroupId) && i.Properties.Any(p => p.Name == nameof(UserInUserGroup.UserId))));
        }
    }
}