using System.Linq.Expressions;
using NavigationModel.Entities;

namespace NavigationDomain.Repositories.Interfaces;

public interface IEntityRepository : IRepository<Entity> {
    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter);
}