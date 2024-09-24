// using FluentAssertions;
// using FluentAssertions.Execution;
// using Xunit;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserInUserRoles;
//
// public class UserInUserRoleIdTests
// {
//     [Fact]
//     public void Constructor_SetsIdCorrectly()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//
//         // Act
//         var userInUserRoleId = new UserInUserRoleId(guid);
//
//         // Assert
//         using (new AssertionScope())
//         {
//             userInUserRoleId.Value.Should().Be(guid);
//         }
//     }
//
//     [Fact]
//     public void Equals_ReturnsTrueForSameId()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//         var userInUserRoleId1 = new UserInUserRoleId(guid);
//         var userInUserRoleId2 = new UserInUserRoleId(guid);
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userInUserRoleId1.Equals(userInUserRoleId2).Should().BeTrue();
//         }
//     }
//
//     [Fact]
//     public void Equals_ReturnsFalseForDifferentId()
//     {
//         // Arrange
//         var userInUserRoleId1 = new UserInUserRoleId(Guid.NewGuid());
//         var userInUserRoleId2 = new UserInUserRoleId(Guid.NewGuid());
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userInUserRoleId1.Equals(userInUserRoleId2).Should().BeFalse();
//         }
//     }
//
//     [Fact]
//     public void GetHashCode_ReturnsSameHashCodeForSameId()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//         var userInUserRoleId1 = new UserInUserRoleId(guid);
//         var userInUserRoleId2 = new UserInUserRoleId(guid);
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userInUserRoleId1.GetHashCode().Should().Be(userInUserRoleId2.GetHashCode());
//         }
//     }
//
//     [Fact]
//     public void GetHashCode_ReturnsDifferentHashCodeForDifferentId()
//     {
//         // Arrange
//         var userInUserRoleId1 = new UserInUserRoleId(Guid.NewGuid());
//         var userInUserRoleId2 = new UserInUserRoleId(Guid.NewGuid());
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userInUserRoleId1.GetHashCode().Should().NotBe(userInUserRoleId2.GetHashCode());
//         }
//     }
// }