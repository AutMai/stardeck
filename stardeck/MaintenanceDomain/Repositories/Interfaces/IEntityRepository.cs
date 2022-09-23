using System.Linq.Expressions;
using MaintenanceModel.Entities;

namespace MaintenanceDomain.Repositories.Interfaces;

public interface IEntityRepository : IRepository<Entity> {
    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter);
}