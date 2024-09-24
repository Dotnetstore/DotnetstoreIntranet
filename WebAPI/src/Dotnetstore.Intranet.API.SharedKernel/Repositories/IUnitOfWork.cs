using Dotnetstore.Intranet.API.SharedKernel.Entities;

namespace Dotnetstore.Intranet.API.SharedKernel.Repositories;

public interface IUnitOfWork
{
    IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;

    Task SaveChangesAsync(CancellationToken cancellationToken);

    void Rollback();
}