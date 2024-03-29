using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Configurations;
using NavigationModel.Entities;

namespace NavigationDomain.Repositories.Implementations;

public class ARepository<TEntity> : IRepository<TEntity> where TEntity : class {
    protected NavigationContext _context;
    protected DbSet<TEntity> _set;

    public ARepository(NavigationContext context) {
        _context = context;
        _set = _context.Set<TEntity>();
    }

    public async Task<TEntity?> ReadAsync(int id) => await _set.FindAsync(id);
    public async Task<List<TEntity>> ReadAsync() => await _set.ToListAsync();

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter) =>
        await _set.Where(filter).ToListAsync();

    public async Task<List<TEntity>> ReadAsync(int start, int count) =>
        await _set.Skip(start).Take(count).ToListAsync();

    public async Task<TEntity> CreateAsync(TEntity entity) {
        _set.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(TEntity entity) {
        _context.ChangeTracker.Clear();
        _set.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity) {
        _set.Remove(entity);
        await _context.SaveChangesAsync();
    }
}