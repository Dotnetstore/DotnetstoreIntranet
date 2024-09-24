// using FluentAssertions;
// using FluentAssertions.Execution;
// using Xunit;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.UserRolesInUserGroups;
//
// public class UserRoleInUserGroupTests
// {
//     [Fact]
//     public void Properties_SetAndGet_ReturnsCorrectValues()
//     {
//         // Arrange
//         var userRoleInUserGroupId = new UserRoleInUserGroupId(Guid.NewGuid());
//         var userRoleId = new UserRoleId(Guid.NewGuid());
//         var userGroupId = new UserGroupId(Guid.NewGuid());
//         var userGroup = new UserGroup
//         {
//             UserGroupId = userGroupId,
//             Name = "Test Group"
//         };
//         var userRole = new UserRole
//         {
//             UserRoleId = userRoleId,
//             Name = "Test Role"
//         };
//         var userRoleInUserGroup = new UserRoleInUserGroup
//         {
//             UserRoleInUserGroupId = userRoleInUserGroupId,
//             UserRoleId = userRoleId,
//             UserGroupId = userGroupId,
//             UserGroup = userGroup,
//             UserRole = userRole
//         };
//
//         // Act & Assert
//         using (new AssertionScope())
//         {
//             userRoleInUserGroup.UserRoleInUserGroupId.Should().Be(userRoleInUserGroupId);
//             userRoleInUserGroup.UserRoleId.Should().Be(userRoleId);
//             userRoleInUserGroup.UserGroupId.Should().Be(userGroupId);
//             userRoleInUserGroup.UserGroup.Should().Be(userGroup);
//             userRoleInUserGroup.UserRole.Should().Be(userRole);
//         }
//     }
// }