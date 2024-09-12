using Dotnetstore.Intranet.WebAPI.Organization.UserRoles;
using Dotnetstore.Intranet.WebAPI.Organization.Users;
using Dotnetstore.Intranet.WebAPI.Utility.Entities;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;

internal sealed class UserInUserRole : BaseAuditableEntity
{
    public UserInUserRoleId Id { get; set; }
    
    public UserId UserId { get; set; }
    
    public UserRoleId UserRoleId { get; set; }

    public User User { get; set; } = null!;
    
    public UserRole UserRole { get; set; } = null!;
}

internal record struct UserInUserRoleId(Guid Value);