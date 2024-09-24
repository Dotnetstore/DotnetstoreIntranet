using Ardalis.Result;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;

internal interface IUserInUserRoleService
{
    ValueTask<Result<bool>> CreateAsync(UserInUserRole userInUserRole, CancellationToken cancellationToken);
}