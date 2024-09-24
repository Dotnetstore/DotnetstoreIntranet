// using Dotnetstore.Intranet.WebAPI.Organization.Users;
// using FluentAssertions;
// using FluentAssertions.Execution;
// using Xunit;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.Users;
//
// public class UserTests
// {
//     [Fact]
//     public void Properties_SetAndGet_ReturnsCorrectValues()
//     {
//         // Arrange
//         var userId = new UserId(Guid.NewGuid());
//         var user = new User
//         {
//             UserId = userId,
//             Username = "TestUser",
//             Password = "TestPassword",
//             Salt1 = "Salt1",
//             Salt2 = "Salt2",
//             Salt3 = "Salt3",
//             Salt4 = "Salt4",
//             IsBlocked = false,
//             BlockedDate = null,
//             EmailVerificationTokens = new List<EmailVerificationToken>(),
//             UserInUserRoles = new List<UserInUserRole>(),
//             UserInUserGroups = new List<UserInUserGroup>(),
//             UserEmails = new List<UserEmail>()
//         };
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             user.UserId.Should().Be(userId);
//             user.Username.Should().Be("TestUser");
//             user.Password.Should().Be("TestPassword");
//             user.Salt1.Should().Be("Salt1");
//             user.Salt2.Should().Be("Salt2");
//             user.Salt3.Should().Be("Salt3");
//             user.Salt4.Should().Be("Salt4");
//             user.IsBlocked.Should().BeFalse();
//             user.BlockedDate.Should().BeNull();
//             user.EmailVerificationTokens.Should().BeEmpty();
//             user.UserInUserRoles.Should().BeEmpty();
//             user.UserInUserGroups.Should().BeEmpty();
//             user.UserEmails.Should().BeEmpty();
//         }
//     }
// }