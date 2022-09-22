﻿using System.Linq.Expressions;
using GameModel.Configurations;
using GameModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameDomain.Repositories;

public class EntityRepository : ARepository<Entity>, IEntityRepository {
    public EntityRepository(TestDbContext context) : base(context) {
    }

    public Task<List<Entity>> ReadGraphAsync(Expression<Func<Entity, bool>> filter) => _set
        .Where(filter).ToListAsync();
}