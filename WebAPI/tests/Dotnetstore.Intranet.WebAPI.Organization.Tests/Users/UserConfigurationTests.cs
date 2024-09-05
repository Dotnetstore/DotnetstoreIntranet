using Dotnetstore.Intranet.WebAPI.Organization.Data;
using Dotnetstore.Intranet.WebAPI.Organization.Users;
using Dotnetstore.Intranet.WebAPI.TestHelper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.Users;

public class UserConfigurationTests
{
    [Fact]
    public void UserId_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(User));
        var userIdProperty = entityType!.FindProperty(nameof(User.UserId));

        // Assert
        userIdProperty.Should().NotBeNull();
        userIdProperty!.IsPrimaryKey().Should().BeTrue();
        userIdProperty.IsNullable.Should().BeFalse();
        userIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
    }

    [Fact]
    public void Username_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(User));
        var usernameProperty = entityType!.FindProperty(nameof(User.Username));

        // Assert
        usernameProperty.Should().NotBeNull();
        usernameProperty!.IsNullable.Should().BeFalse();
    }
}