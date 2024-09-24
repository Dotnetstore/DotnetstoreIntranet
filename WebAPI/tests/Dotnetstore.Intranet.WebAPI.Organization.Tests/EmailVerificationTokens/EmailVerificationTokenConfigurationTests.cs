// using Dotnetstore.Intranet.WebAPI.Organization.Data;
// using Dotnetstore.Intranet.WebAPI.TestHelper.Data;
// using FluentAssertions;
// using FluentAssertions.Execution;
// using Microsoft.EntityFrameworkCore.Metadata;
// using Xunit;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.EmailVerificationTokens;
//
// public class EmailVerificationTokenConfigurationTests
// {
//     [Fact]
//     public void Id_IsConfiguredCorrectly()
//     {
//         // Arrange
//         var options = DataHelper.CreateOptions<OrganizationDataContext>();
//
//         // Act
//         using var context = new OrganizationDataContext(options);
//         var entityType = context.Model.FindEntityType(typeof(EmailVerificationToken));
//         var idProperty = entityType!.FindProperty(nameof(EmailVerificationToken.Id));
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
//         var entityType = context.Model.FindEntityType(typeof(EmailVerificationToken));
//         var userIdProperty = entityType!.FindProperty(nameof(EmailVerificationToken.UserId));
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
//     public void ExpireDate_IsConfiguredCorrectly()
//     {
//         // Arrange
//         var options = DataHelper.CreateOptions<OrganizationDataContext>();
//
//         // Act
//         using var context = new OrganizationDataContext(options);
//         var entityType = context.Model.FindEntityType(typeof(EmailVerificationToken));
//         var expireDateProperty = entityType!.FindProperty(nameof(EmailVerificationToken.ExpireDate));
//
//         // Assert
//         using (new AssertionScope())
//         {
//             expireDateProperty.Should().NotBeNull();
//             expireDateProperty!.IsNullable.Should().BeFalse();
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
//         var entityType = context.Model.FindEntityType(typeof(EmailVerificationToken));
//         var indexes = entityType!.GetIndexes();
//
//         // Assert
//         using (new AssertionScope())
//         {
//             indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(EmailVerificationToken.Id)));
//             indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(EmailVerificationToken.UserId)));
//             indexes.Should().ContainSingle(i => i.Properties.Any(p => p.Name == nameof(EmailVerificationToken.ExpireDate)));
//         }
//     }
// }