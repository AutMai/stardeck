using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Configurations;
using NavigationModel.Entities;


namespace NavigationDomain.Repositories.Implementations;

public class PlanetRepository : ARepository<Planet>, IPlanetRepository {
    public PlanetRepository(NavigationContext context) : base(context) {
    }

    public new async Task<List<Planet>> ReadAsync() {
        var r = await _set.Include(p => p.Galaxy).ToListAsync();
        return r;
    }

    public new async Task<Planet> ReadAsync(int id)
        => await _set.Where(p => p.LocationId == id).Include(p => p.Galaxy).SingleOrDefaultAsync();
}