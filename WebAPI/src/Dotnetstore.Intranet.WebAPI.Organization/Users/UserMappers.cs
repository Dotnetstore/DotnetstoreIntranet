using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Responses;

namespace Dotnetstore.Intranet.WebAPI.Organization.Users;

internal static class UserMappers
{
    internal static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.UserId.Value,
            FirstName = user.FirstName,
            MiddleName = user.MiddleName,
            LastName = user.LastName,
            EnglishName = user.EnglishName,
            SocialSecurityNumber = user.SocialSecurityNumber,
            DateOfBirth = user.DateOfBirth,
            IsMale = user.IsMale,
            LastNameFirst = user.LastNameFirst,
            IsBlocked = user.IsBlocked,
            IsDeleted = user.IsDeleted,
            UserGroups = user.ToUserGroupList(),
            UserRoles = user.ToUserRoleList(),
            UserEmails = user.ToUserEmailList()
        };
    }
    
    private static List<string> ToUserEmailList(this User user)
    {
        return user.UserEmails.Select(x => x.EmailAddress).ToList();
    }
    
    private static List<string> ToUserGroupList(this User user)
    {
        return user.UserInUserGroups.Select(x => x.UserGroup.Name).ToList();
    }
    
    private static List<string> ToUserRoleList(this User user)
    {
        var list = new List<string>();
        list.AddRange(user.UserInUserRoles.Select(x => x.UserRole.Name));
        list.AddRange(user.UserInUserGroups.SelectMany(x => x.UserGroup.UserRoleInUserGroups).Select(x => x.UserRole.Name));
        return list;
    }
}