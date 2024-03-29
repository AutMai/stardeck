using System.Linq.Expressions;

namespace MaintenanceDomain.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class {
    Task<TEntity> CreateAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);

    Task<TEntity?> ReadAsync(int id);

    Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter);
    Task<List<TEntity>> ReadAsync();
    Task<List<TEntity>> ReadAsync(int start, int count);
}