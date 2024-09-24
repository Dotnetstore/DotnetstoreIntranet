// using FluentAssertions;
// using FluentAssertions.Execution;
// using Xunit;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserRolesInUserGroups;
//
// public class UserRoleInUserGroupIdTests
// {
//     [Fact]
//     public void Constructor_SetsIdCorrectly()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//
//         // Act
//         var userRoleInUserGroupId = new UserRoleInUserGroupId(guid);
//
//         // Assert
//         using (new AssertionScope())
//         {
//             userRoleInUserGroupId.Value.Should().Be(guid);
//         }
//     }
//
//     [Fact]
//     public void Equals_ReturnsTrueForSameId()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//         var userRoleInUserGroupId1 = new UserRoleInUserGroupId(guid);
//         var userRoleInUserGroupId2 = new UserRoleInUserGroupId(guid);
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userRoleInUserGroupId1.Equals(userRoleInUserGroupId2).Should().BeTrue();
//         }
//     }
//
//     [Fact]
//     public void Equals_ReturnsFalseForDifferentId()
//     {
//         // Arrange
//         var userRoleInUserGroupId1 = new UserRoleInUserGroupId(Guid.NewGuid());
//         var userRoleInUserGroupId2 = new UserRoleInUserGroupId(Guid.NewGuid());
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userRoleInUserGroupId1.Equals(userRoleInUserGroupId2).Should().BeFalse();
//         }
//     }
//
//     [Fact]
//     public void GetHashCode_ReturnsSameHashCodeForSameId()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//         var userRoleInUserGroupId1 = new UserRoleInUserGroupId(guid);
//         var userRoleInUserGroupId2 = new UserRoleInUserGroupId(guid);
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userRoleInUserGroupId1.GetHashCode().Should().Be(userRoleInUserGroupId2.GetHashCode());
//         }
//     }
//
//     [Fact]
//     public void GetHashCode_ReturnsDifferentHashCodeForDifferentId()
//     {
//         // Arrange
//         var userRoleInUserGroupId1 = new UserRoleInUserGroupId(Guid.NewGuid());
//         var userRoleInUserGroupId2 = new UserRoleInUserGroupId(Guid.NewGuid());
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userRoleInUserGroupId1.GetHashCode().Should().NotBe(userRoleInUserGroupId2.GetHashCode());
//         }
//     }
// }