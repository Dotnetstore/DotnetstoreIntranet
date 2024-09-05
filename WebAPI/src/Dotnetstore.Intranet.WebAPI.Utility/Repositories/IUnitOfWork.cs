using Dotnetstore.Intranet.WebAPI.Utility.Entities;

namespace Dotnetstore.Intranet.WebAPI.Utility.Repositories;

public interface IUnitOfWork
{
    IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;

    Task SaveChangesAsync(CancellationToken cancellationToken);

    void Rollback();
}