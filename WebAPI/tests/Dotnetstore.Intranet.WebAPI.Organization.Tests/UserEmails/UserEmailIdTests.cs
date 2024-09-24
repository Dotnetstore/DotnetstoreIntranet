// using FluentAssertions;
// using FluentAssertions.Execution;
// using Xunit;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserEmails;
//
// public class UserEmailIdTests
// {
//     [Fact]
//     public void Constructor_SetsIdCorrectly()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//
//         // Act
//         var userEmailId = new UserEmailId(guid);
//
//         // Assert
//         using (new AssertionScope())
//         {
//             userEmailId.Value.Should().Be(guid);
//         }
//     }
//
//     [Fact]
//     public void Equals_ReturnsTrueForSameId()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//         var userEmailId1 = new UserEmailId(guid);
//         var userEmailId2 = new UserEmailId(guid);
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userEmailId1.Equals(userEmailId2).Should().BeTrue();
//         }
//     }
//
//     [Fact]
//     public void Equals_ReturnsFalseForDifferentId()
//     {
//         // Arrange
//         var userEmailId1 = new UserEmailId(Guid.NewGuid());
//         var userEmailId2 = new UserEmailId(Guid.NewGuid());
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userEmailId1.Equals(userEmailId2).Should().BeFalse();
//         }
//     }
//
//     [Fact]
//     public void GetHashCode_ReturnsSameHashCodeForSameId()
//     {
//         // Arrange
//         var guid = Guid.NewGuid();
//         var userEmailId1 = new UserEmailId(guid);
//         var userEmailId2 = new UserEmailId(guid);
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userEmailId1.GetHashCode().Should().Be(userEmailId2.GetHashCode());
//         }
//     }
//
//     [Fact]
//     public void GetHashCode_ReturnsDifferentHashCodeForDifferentId()
//     {
//         // Arrange
//         var userEmailId1 = new UserEmailId(Guid.NewGuid());
//         var userEmailId2 = new UserEmailId(Guid.NewGuid());
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userEmailId1.GetHashCode().Should().NotBe(userEmailId2.GetHashCode());
//         }
//     }
// }