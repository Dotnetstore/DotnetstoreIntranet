// using Dotnetstore.Intranet.WebAPI.Organization.Users;
// using FluentAssertions;
// using FluentAssertions.Execution;
// using Xunit;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserInUserRoles;
//
// public class UserInUserRoleTests
// {
//     [Fact]
//     public void Properties_SetAndGet_ReturnsCorrectValues()
//     {
//         // Arrange
//         var userInUserRoleId = new UserInUserRoleId(Guid.NewGuid());
//         var userId = new UserId(Guid.NewGuid());
//         var userRoleId = new UserRoleId(Guid.NewGuid());
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
//             BlockedDate = null
//         };
//         var userRole = new UserRole
//         {
//             UserRoleId = userRoleId,
//             Name = "Test Role"
//         };
//         var userInUserRole = new UserInUserRole
//         {
//             Id = userInUserRoleId,
//             UserId = userId,
//             UserRoleId = userRoleId,
//             User = user,
//             UserRole = userRole
//         };
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userInUserRole.Id.Should().Be(userInUserRoleId);
//             userInUserRole.UserId.Should().Be(userId);
//             userInUserRole.UserRoleId.Should().Be(userRoleId);
//             userInUserRole.User.Should().Be(user);
//             userInUserRole.UserRole.Should().Be(userRole);
//         }
//     }
// }