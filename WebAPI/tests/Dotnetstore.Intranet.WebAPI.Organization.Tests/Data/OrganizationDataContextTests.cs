using Dotnetstore.Intranet.WebAPI.Organization.Data;
using Dotnetstore.Intranet.WebAPI.Organization.Users;
using Dotnetstore.Intranet.WebAPI.TestHelper.Data;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.Data;

public class OrganizationDataContextTests
{
    [Fact]
    public void Users_DbSet_IsConfigured()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);

        // Assert
        context.Users.Should().NotBeNull();
    }

    [Fact]
    public void DefaultSchema_IsSetToOrganization()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var model = context.Model;
        var schema = model.GetDefaultSchema();

        // Assert
        schema.Should().Be("Organization");
    }

    [Fact]
    public void Configurations_AreAppliedFromAssembly()
    {
        // Arrange
        var options = DataHelper.CreateOptions<OrganizationDataContext>();

        // Act
        using var context = new OrganizationDataContext(options);
        var entityType = context.Model.FindEntityType(typeof(User));

        // Assert
        using (new AssertionScope())
        {
            entityType!.Should().NotBeNull();
            entityType!.GetTableName().Should().Be("User");
            entityType!.GetProperties().Should().ContainSingle(p => p.Name == "UserId");
        }
    }
}