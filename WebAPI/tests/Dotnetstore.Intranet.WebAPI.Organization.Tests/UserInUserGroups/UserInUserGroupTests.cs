// using Dotnetstore.Intranet.WebAPI.Organization.Users;
// using FluentAssertions;
// using FluentAssertions.Execution;
// using Xunit;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserInUserGroups;
//
// public class UserInUserGroupTests
// {
//     [Fact]
//     public void Properties_SetAndGet_ReturnsCorrectValues()
//     {
//         // Arrange
//         var userInUserGroupId = new UserInUserGroupId(Guid.NewGuid());
//         var userId = new UserId(Guid.NewGuid());
//         var userGroupId = new UserGroupId(Guid.NewGuid());
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
//         var userGroup = new UserGroup
//         {
//             UserGroupId = userGroupId,
//             Name = "Test Group"
//         };
//         var userInUserGroup = new UserInUserGroup
//         {
//             Id = userInUserGroupId,
//             UserId = userId,
//             UserGroupId = userGroupId,
//             User = user,
//             UserGroup = userGroup
//         };
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userInUserGroup.Id.Should().Be(userInUserGroupId);
//             userInUserGroup.UserId.Should().Be(userId);
//             userInUserGroup.UserGroupId.Should().Be(userGroupId);
//             userInUserGroup.User.Should().Be(user);
//             userInUserGroup.UserGroup.Should().Be(userGroup);
//         }
//     }
// }