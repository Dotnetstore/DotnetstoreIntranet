﻿using Dotnetstore.Intranet.WebAPI.Utility.Entities;

namespace Dotnetstore.Intranet.WebAPI.Utility.Repositories;

public interface IGenericRepository<T> where T : class, IBaseAuditableEntity
{
    IQueryable<T> Entities { get; }

    Task<T?> GetByIdAsync(Guid id);

    Task<List<T>> GetAllAsync();

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);
}