using System.Linq.Expressions;
using CrewDomain.Repositories.Interfaces;
using CrewModel.Configurations;
using CrewModel.Entities;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;

namespace CrewDomain.Repositories.Implementations;

public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : class {
    private Crew.Crew.CrewClient _client;

    protected ARepository() {
        var channel = GrpcChannel.ForAddress("http://localhost:5151");
        _client = new Crew.Crew.CrewClient(channel);
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