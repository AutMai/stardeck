using System.Linq.Expressions;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Configurations;
using MaintenanceModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceDomain.Repositories.Implementations;

public class EntityRepository : ARepository<Entity>, IEntityRepository {
    public EntityRepository(TestDbContext context) : base(context) {
    }

    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter) => _set
        .Where(filter).ToListAsync();
}