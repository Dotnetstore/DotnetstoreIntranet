// using FluentAssertions;
// using FluentAssertions.Execution;
// using Xunit;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserInUserGroups;
//
// public class UserInUserGroupIdTests
// {
//     [Fact]
//     public void Constructor_SetsIdCorrectly()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//
//         // Act
//         var userInUserGroupId = new UserInUserGroupId(guid);
//
//         // Assert
//         using (new AssertionScope())
//         {
//             userInUserGroupId.Value.Should().Be(guid);
//         }
//     }
//
//     [Fact]
//     public void Equals_ReturnsTrueForSameId()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//         var userInUserGroupId1 = new UserInUserGroupId(guid);
//         var userInUserGroupId2 = new UserInUserGroupId(guid);
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userInUserGroupId1.Equals(userInUserGroupId2).Should().BeTrue();
//         }
//     }
//
//     [Fact]
//     public void Equals_ReturnsFalseForDifferentId()
//     {
//         // Arrange
//         var userInUserGroupId1 = new UserInUserGroupId(Guid.NewGuid());
//         var userInUserGroupId2 = new UserInUserGroupId(Guid.NewGuid());
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userInUserGroupId1.Equals(userInUserGroupId2).Should().BeFalse();
//         }
//     }
//
//     [Fact]
//     public void GetHashCode_ReturnsSameHashCodeForSameId()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//         var userInUserGroupId1 = new UserInUserGroupId(guid);
//         var userInUserGroupId2 = new UserInUserGroupId(guid);
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userInUserGroupId1.GetHashCode().Should().Be(userInUserGroupId2.GetHashCode());
//         }
//     }
//
//     [Fact]
//     public void GetHashCode_ReturnsDifferentHashCodeForDifferentId()
//     {
//         // Arrange
//         var userInUserGroupId1 = new UserInUserGroupId(Guid.NewGuid());
//         var userInUserGroupId2 = new UserInUserGroupId(Guid.NewGuid());
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userInUserGroupId1.GetHashCode().Should().NotBe(userInUserGroupId2.GetHashCode());
//         }
//     }
// }