using System.Linq.Expressions;
using AuthModel.Configurations;
using AuthModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthDomain.Repositories;

public class EntityRepository : ARepository<Entity>, IEntityRepository {
    public EntityRepository(TestDbContext context) : base(context) {
    }

    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter) => _set
        .Where(filter).ToListAsync();
}