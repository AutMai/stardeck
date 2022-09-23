using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Configurations;
using NavigationModel.Entities;


namespace NavigationDomain.Repositories.Implementations;

public class EntityRepository : ARepository<Entity>, IEntityRepository {
    public EntityRepository(TestDbContext context) : base(context) {
    }

    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter) => _set
        .Where(filter).ToListAsync();
}