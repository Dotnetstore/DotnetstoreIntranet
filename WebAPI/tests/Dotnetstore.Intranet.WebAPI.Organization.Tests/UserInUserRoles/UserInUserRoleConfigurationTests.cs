// using Dotnetstore.Intranet.WebAPI.Organization.Data;
// using Dotnetstore.Intranet.WebAPI.TestHelper.Data;
// using FluentAssertions;
// using FluentAssertions.Execution;
// using Microsoft.EntityFrameworkCore.Metadata;
// using Xunit;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserInUserRoles;
//
// public class UserInUserRoleConfigurationTests
// {
//     [Fact]
//     public void Id_IsConfiguredCorrectly()
//     {
//         // Arrange
//         var options = DataHelper.CreateOptions<OrganizationDataContext>();
//
//         // Act
//         using var context = new OrganizationDataContext(options);
//         var entityType = context.Model.FindEntityType(typeof(UserInUserRole));
//         var idProperty = entityType!.FindProperty(nameof(UserInUserRole.Id));
//
//         // Assert
//         using (new AssertionScope())
//         {
//             idProperty.Should().NotBeNull();
//             idProperty!.IsPrimaryKey().Should().BeTrue();
//             idProperty.IsNullable.Should().BeFalse();
//             idProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
//         }
//     }
//
//     [Fact]
//     public void UserId_IsConfiguredCorrectly()
//     {
//         // Arrange
//         var options = DataHelper.CreateOptions<OrganizationDataContext>();
//
//         // Act
//         using var context = new OrganizationDataContext(options);
//         var entityType = context.Model.FindEntityType(typeof(UserInUserRole));
//         var userIdProperty = entityType!.FindProperty(nameof(UserInUserRole.UserId));
//
//         // Assert
//         using (new AssertionScope())
//         {
//             userIdProperty.Should().NotBeNull();
//             userIdProperty!.IsNullable.Should().BeFalse();
//             userIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
//         }
//     }
//
//     [Fact]
//     public void UserRoleId_IsConfiguredCorrectly()
//     {
//         // Arrange
//         var options = DataHelper.CreateOptions<OrganizationDataContext>();
//
//         // Act
//         using var context = new OrganizationDataContext(options);
//         var entityType = context.Model.FindEntityType(typeof(UserInUserRole));
//         var userRoleIdProperty = entityType!.FindProperty(nameof(UserInUserRole.UserRoleId));
//
//         // Assert
//         using (new AssertionScope())
//         {
//             userRoleIdProperty.Should().NotBeNull();
//             userRoleIdProperty!.IsNullable.Should().BeFalse();
//             userRoleIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
//         }
//     }
//
//     [Fact]
//     public void Indexes_AreConfiguredCorrectly()
//     {
//         // Arrange
//         var options = DataHelper.CreateOptions<OrganizationDataContext>();
//
//         // Act
//         using var context = new OrganizationDataContext(options);
//         var entityType = context.Model.FindEntityType(typeof(UserInUserRole));
//         var indexes = entityType!.GetIndexes();
//
//         // Assert
//         using (new AssertionScope())
//         {
//             indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserInUserRole.Id)));
//             indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(UserInUserRole.UserRoleId) && i.Properties.Any(p => p.Name == nameof(UserInUserRole.UserId))));
//         }
//     }
// }