using Dotnetstore.Intranet.API.Organization.UserInUserRoles;
using Dotnetstore.Intranet.API.Organization.UserRolesInUserGroups;
using Dotnetstore.Intranet.API.SharedKernel.Entities;

namespace Dotnetstore.Intranet.API.Organization.UserRoles;

internal sealed class UserRole : BaseAuditableEntity
{
    public UserRoleId UserRoleId { get; set; }

    public string Name { get; set; } = null!;
    
    public ICollection<UserRoleInUserGroup> UserRoleInUserGroups { get; set; } = new List<UserRoleInUserGroup>();
    
    public ICollection<UserInUserRole> UserInUserRoles { get; set; } = new List<UserInUserRole>();
}

internal record struct UserRoleId(Guid Value);