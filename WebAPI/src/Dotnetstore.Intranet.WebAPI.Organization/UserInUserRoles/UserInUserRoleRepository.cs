using Dotnetstore.Intranet.WebAPI.Utility.Repositories;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;

internal sealed class UserInUserRoleRepository(IUnitOfWork unitOfWork) : IUserInUserRoleRepository
{
    void IUserInUserRoleRepository.Create(UserInUserRole userInUserRole)
    {
        unitOfWork.Repository<UserInUserRole>().Create(userInUserRole);
    }

    async ValueTask IUserInUserRoleRepository.SaveChangesAsync(CancellationToken ct)
    {
        await unitOfWork.SaveChangesAsync(ct);
    }
}