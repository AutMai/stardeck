using System.Linq.Expressions;
using CrewModel.Entities;

namespace CrewDomain.Repositories.Interfaces;

public interface IEntityRepository : IRepository<Entity> {
    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter);
}