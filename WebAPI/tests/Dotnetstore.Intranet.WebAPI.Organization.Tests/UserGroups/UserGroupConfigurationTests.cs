using Dotnetstore.Intranet.WebAPI.Organization.Data;
using Dotnetstore.Intranet.WebAPI.Organization.UserGroups;
using Dotnetstore.Intranet.WebAPI.TestHelper.Data;
using Dotnetstore.Intranet.WebAPI.Utility.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserGroups;

public class UserGroupConfigurationTests
{
    [Fact]
    public void UserGroupId_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserGroup));
        var userGroupIdProperty = entityType!.FindProperty(nameof(UserGroup.UserGroupId));

        // Assert
        using (new AssertionScope())
        {
            userGroupIdProperty.Should().NotBeNull();
            userGroupIdProperty!.IsPrimaryKey().Should().BeTrue();
            userGroupIdProperty.IsNullable.Should().BeFalse();
            userGroupIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }

    [Fact]
    public void Name_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserGroup));
        var nameProperty = entityType!.FindProperty(nameof(UserGroup.Name));

        // Assert
        using (new AssertionScope())
        {
            nameProperty.Should().NotBeNull();
            nameProperty!.IsNullable.Should().BeFalse();
            nameProperty.GetMaxLength().Should().Be(Constants.DefaultNameLength);
            nameProperty.IsUnicode().Should().BeTrue();
        }
    }

    [Fact]
    public void Indexes_AreConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserGroup));
        var indexes = entityType!.GetIndexes();

        // Assert
        using (new AssertionScope())
        {
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserGroup.UserGroupId)));
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserGroup.IsDeleted)));
        }
    }
}