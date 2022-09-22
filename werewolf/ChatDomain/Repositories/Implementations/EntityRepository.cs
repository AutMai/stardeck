using System.Linq.Expressions;
using ChatModel.Configurations;
using ChatModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatDomain.Repositories;

public class EntityRepository : ARepository<Entity>, IEntityRepository {
    public EntityRepository(TestDbContext context) : base(context) {
    }

    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter) => _set
        .Where(filter).ToListAsync();
}