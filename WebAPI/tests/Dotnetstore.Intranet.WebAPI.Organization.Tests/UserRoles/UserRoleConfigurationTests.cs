using Dotnetstore.Intranet.WebAPI.Organization.Data;
using Dotnetstore.Intranet.WebAPI.Organization.UserRoles;
using Dotnetstore.Intranet.WebAPI.TestHelper.Data;
using Dotnetstore.Intranet.WebAPI.Utility.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserRoles;

public class UserRoleConfigurationTests
{
    [Fact]
    public void UserRoleId_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserRole));
        var userRoleIdProperty = entityType!.FindProperty(nameof(UserRole.UserRoleId));

        // Assert
        using (new AssertionScope())
        {
            userRoleIdProperty.Should().NotBeNull();
            userRoleIdProperty!.IsPrimaryKey().Should().BeTrue();
            userRoleIdProperty.IsNullable.Should().BeFalse();
            userRoleIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }

    [Fact]
    public void Name_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserRole));
        var nameProperty = entityType!.FindProperty(nameof(UserRole.Name));

        // Assert
        using (new AssertionScope())
        {
            nameProperty.Should().NotBeNull();
            nameProperty!.IsNullable.Should().BeFalse();
            nameProperty.IsUnicode().Should().BeTrue();
            nameProperty.GetMaxLength().Should().Be(Constants.DefaultNameLength);
        }
    }

    [Fact]
    public void Indexes_AreConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserRole));
        var indexes = entityType!.GetIndexes();

        // Assert
        using (new AssertionScope())
        {
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserRole.UserRoleId)) && i.IsUnique);
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserRole.IsDeleted)));
        }
    }
}