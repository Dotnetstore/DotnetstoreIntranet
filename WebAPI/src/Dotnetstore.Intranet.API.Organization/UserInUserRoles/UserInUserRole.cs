using Dotnetstore.Intranet.API.Organization.UserRoles;
using Dotnetstore.Intranet.API.Organization.Users;
using Dotnetstore.Intranet.API.SharedKernel.Entities;

namespace Dotnetstore.Intranet.API.Organization.UserInUserRoles;

internal sealed class UserInUserRole : BaseAuditableEntity
{
    public UserInUserRoleId Id { get; set; }
    
    public UserId UserId { get; set; }
    
    public UserRoleId UserRoleId { get; set; }

    public User User { get; set; } = null!;
    
    public UserRole UserRole { get; set; } = null!;
}

internal record struct UserInUserRoleId(Guid Value);