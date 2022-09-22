using System.Linq.Expressions;
using AuthModel.Entities;

namespace AuthDomain.Repositories;

public interface IEntityRepository : IRepository<Entity> {
    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter);
}