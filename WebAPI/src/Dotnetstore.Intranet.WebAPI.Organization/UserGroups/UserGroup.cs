using Dotnetstore.Intranet.WebAPI.Organization.UserInUserGroups;
using Dotnetstore.Intranet.WebAPI.Organization.UserRolesInUserGroups;
using Dotnetstore.Intranet.WebAPI.Utility.Entities;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserGroups;

internal sealed class UserGroup : BaseAuditableEntity
{
    public UserGroupId UserGroupId { get; set; }

    public string Name { get; set; } = null!;
    
    public ICollection<UserRoleInUserGroup> UserRoleInUserGroups { get; set; } = new List<UserRoleInUserGroup>();
    
    public ICollection<UserInUserGroup> UserInUserGroups { get; set; } = new List<UserInUserGroup>();
}

internal record struct UserGroupId(Guid Value);