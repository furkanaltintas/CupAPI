﻿using CupAPI.Application.Interfaces;
using CupAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CupAPI.Persistence.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IQueryable<T>>? include = null, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = AsQueryable();
        if (predicate is not null) query = query.Where(predicate);

        if (include is not null) query = include(query);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? include = null, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = AsQueryable();
        query = query.Where(predicate);

        if (include is not null) query = include(query);

        return await query.FirstOrDefaultAsync(cancellationToken);

    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        var isDeletedProp = typeof(T).GetProperty("IsDeleted");
        if (isDeletedProp != null && isDeletedProp.PropertyType == typeof(bool))
        {
            isDeletedProp.SetValue(entity, true);
            _dbSet.Update(entity);
        }
        else
        {
            _dbSet.Remove(entity);
        }
    }

    public async Task DeleteWhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var entities = await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        foreach (var entity in entities)
        {
            Delete(entity);
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<T> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }
}
