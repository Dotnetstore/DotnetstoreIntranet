using Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;
using Dotnetstore.Intranet.WebAPI.Organization.UserRolesInUserGroups;
using Dotnetstore.Intranet.WebAPI.Utility.Entities;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserRoles;

internal sealed class UserRole : BaseAuditableEntity
{
    public UserRoleId UserRoleId { get; set; }

    public string Name { get; set; } = null!;
    
    public ICollection<UserRoleInUserGroup> UserRoleInUserGroups { get; set; } = new List<UserRoleInUserGroup>();
    
    public ICollection<UserInUserRole> UserInUserRoles { get; set; } = new List<UserInUserRole>();
}

internal record struct UserRoleId(Guid Value);