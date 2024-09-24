namespace Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;

internal interface IUserInUserRoleRepository
{
    void Create(UserInUserRole userInUserRole);
    
    ValueTask SaveChangesAsync(CancellationToken ct);
}