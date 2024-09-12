using Dotnetstore.Intranet.WebAPI.Organization.UserGroups;
using Dotnetstore.Intranet.WebAPI.Organization.UserRoles;
using Dotnetstore.Intranet.WebAPI.Utility.Entities;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserRolesInUserGroups;

internal sealed class UserRoleInUserGroup : BaseAuditableEntity
{
    public UserRoleInUserGroupId UserRoleInUserGroupId { get; set; }

    public UserRoleId UserRoleId { get; set; }
    
    public UserGroupId UserGroupId { get; set; }

    public UserGroup UserGroup { get; set; } = null!;
    
    public UserRole UserRole { get; set; } = null!;
}

internal record struct UserRoleInUserGroupId(Guid Value);