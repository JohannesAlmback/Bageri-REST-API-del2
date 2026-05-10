using System.Linq.Expressions;
using core.Entities;

namespace core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<IReadOnlyList<T>> ListAllIncludesAsync(params Expression<Func<T, object>>[] includes);
    Task<T?> FindByIdWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes);
    Task<T?> FindByIdAsync(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
    Task<bool> SaveAllAsync();
}
