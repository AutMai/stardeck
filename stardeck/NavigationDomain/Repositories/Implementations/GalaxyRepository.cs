using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Configurations;
using NavigationModel.Entities;


namespace NavigationDomain.Repositories.Implementations;

public class GalaxyRepository : ARepository<Galaxy>, IGalaxyRepository {
    public GalaxyRepository(NavigationContext context) : base(context) {
    }

    public new async Task<List<Galaxy>> ReadAsync() {
        var r = await _set.Include(g => g.Planets).ToListAsync();
        return r;
    }

    public new async Task<Galaxy> ReadAsync(int id) {
        var r = await _set.Where(g => g.LocationId == id).Include(g => g.Planets).SingleOrDefaultAsync();
        return r;
    }
}