using Ardalis.Result;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;

internal sealed class UserInUserRoleService(IUserInUserRoleRepository userInUserRoleRepository) : IUserInUserRoleService
{
    async ValueTask<Result<bool>> IUserInUserRoleService.CreateAsync(UserInUserRole userInUserRole, CancellationToken cancellationToken)
    {
        userInUserRoleRepository.Create(userInUserRole);
        await userInUserRoleRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}