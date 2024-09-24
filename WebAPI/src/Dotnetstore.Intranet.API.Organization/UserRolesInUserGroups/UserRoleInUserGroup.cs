using Dotnetstore.Intranet.API.Organization.UserGroups;
using Dotnetstore.Intranet.API.Organization.UserRoles;
using Dotnetstore.Intranet.API.SharedKernel.Entities;

namespace Dotnetstore.Intranet.API.Organization.UserRolesInUserGroups;

internal sealed class UserRoleInUserGroup : BaseAuditableEntity
{
    public UserRoleInUserGroupId UserRoleInUserGroupId { get; set; }

    public UserRoleId UserRoleId { get; set; }
    
    public UserGroupId UserGroupId { get; set; }

    public UserGroup UserGroup { get; set; } = null!;
    
    public UserRole UserRole { get; set; } = null!;
}

internal record struct UserRoleInUserGroupId(Guid Value);