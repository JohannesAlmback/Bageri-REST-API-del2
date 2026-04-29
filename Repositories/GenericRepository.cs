using System.Linq.Expressions;
using Mormor_Dagnys_Bageri_REST_API.Data;
using Mormor_Dagnys_Bageri_REST_API.Entities;
using Mormor_Dagnys_Bageri_REST_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mormor_Dagnys_Bageri_REST_API.Repositories;

public class GenericRepository<T>(MormorDagnysContext context) : IGenericRepository<T> where T : BaseEntity
{
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public async Task<T> FindByIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> ListAllIncludesAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = context.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async Task<T> FindByIdWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = context.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public void Update(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
    }

    public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return context.Set<T>().Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
