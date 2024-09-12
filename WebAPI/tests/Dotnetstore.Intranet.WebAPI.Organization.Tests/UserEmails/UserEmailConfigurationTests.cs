using Dotnetstore.Intranet.WebAPI.Organization.Data;
using Dotnetstore.Intranet.WebAPI.Organization.UserEmails;
using Dotnetstore.Intranet.WebAPI.TestHelper.Data;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserEmails;

public class UserEmailConfigurationTests
{
    [Fact]
    public void UserEmailId_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserEmail));
        var userEmailIdProperty = entityType!.FindProperty(nameof(UserEmail.UserEmailId));

        // Assert
        using (new AssertionScope())
        {
            userEmailIdProperty.Should().NotBeNull();
            userEmailIdProperty!.IsPrimaryKey().Should().BeTrue();
            userEmailIdProperty.IsNullable.Should().BeFalse();
            userEmailIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }

    [Fact]
    public void UserId_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserEmail));
        var userIdProperty = entityType!.FindProperty(nameof(UserEmail.UserId));

        // Assert
        using (new AssertionScope())
        {
            userIdProperty.Should().NotBeNull();
            userIdProperty!.IsNullable.Should().BeFalse();
            userIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        }
    }

    [Fact]
    public void EmailType_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserEmail));
        var emailTypeProperty = entityType!.FindProperty(nameof(UserEmail.EmailType));

        // Assert
        using (new AssertionScope())
        {
            emailTypeProperty.Should().NotBeNull();
            emailTypeProperty!.IsNullable.Should().BeFalse();
        }
    }

    [Fact]
    public void EmailAddress_IsConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserEmail));
        var emailAddressProperty = entityType!.FindProperty(nameof(UserEmail.EmailAddress));

        // Assert
        using (new AssertionScope())
        {
            emailAddressProperty.Should().NotBeNull();
            emailAddressProperty!.IsNullable.Should().BeFalse();
            emailAddressProperty.GetMaxLength().Should().Be(255);
            emailAddressProperty.IsUnicode().Should().BeFalse();
        }
    }

    [Fact]
    public void Indexes_AreConfiguredCorrectly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(UserEmail));
        var indexes = entityType!.GetIndexes();

        // Assert
        using (new AssertionScope())
        {
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserEmail.UserEmailId)));
            indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserEmail.IsDeleted)));
        }
    }
}