using System.Linq.Expressions;
using GameModel.Entities;

namespace GameDomain.Repositories;

public interface IEntityRepository : IRepository<Entity> {
    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter);
}