using System.Linq.Expressions;
using ChatModel.Entities;

namespace ChatDomain.Repositories;

public interface IEntityRepository : IRepository<Entity> {
    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter);
}