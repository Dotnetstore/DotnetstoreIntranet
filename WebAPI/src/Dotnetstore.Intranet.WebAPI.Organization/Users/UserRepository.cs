using Dotnetstore.Intranet.WebAPI.Organization.Data;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Intranet.WebAPI.Organization.Users;

internal sealed class UserRepository(IOrganizationUnitOfWork unitOfWork) : IUserRepository
{
    private IQueryable<User> GetUserQuery()
    {
        return unitOfWork
            .Repository<User>()
            .Entities
            .Include(x =>  x.UserEmails)
            .Include(x => x.UserInUserGroups)
            .ThenInclude(x => x.UserGroup)
            .ThenInclude(x => x.UserRoleInUserGroups)
            .ThenInclude(x => x.UserRole)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            .Include(x => x.UserInUserRoles)
            .ThenInclude(x => x.UserRole)
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .ThenBy(x => x.MiddleName)
            .ThenBy(x => x.EnglishName)
            .ThenBy(x => x.SocialSecurityNumber);
    }

    async ValueTask<List<User>> IUserRepository.GetAllNotSystemAsync(CancellationToken ct)
    {
        var query = GetUserQuery();
        
        return await query
            .AsNoTracking()
            .Where(x => !x.IsSystem)
            .ToListAsync(cancellationToken: ct);
    }
}