using System.Linq.Expressions;
using CrewDomain.Repositories.Interfaces;
using CrewModel.Configurations;
using CrewModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrewDomain.Repositories.Implementations;

public class EntityRepository : ARepository<Entity>, IEntityRepository {
    public EntityRepository(TestDbContext context) : base(context) {
    }

    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter) => _set
        .Where(filter).ToListAsync();
}