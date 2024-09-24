﻿using Dotnetstore.Intranet.API.SharedKernel.Entities;

namespace Dotnetstore.Intranet.API.SharedKernel.Repositories;

public interface IGenericRepository<T> where T : class, IBaseAuditableEntity
{
    IQueryable<T> Entities { get; }

    Task<T?> GetByIdAsync(Guid id);

    Task<List<T>> GetAllAsync();

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);
}