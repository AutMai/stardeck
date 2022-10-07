using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Configurations;
using NavigationModel.Entities;


namespace NavigationDomain.Repositories.Implementations;

public class RouteRepository : ARepository<Route>, IRouteRepository {
    public RouteRepository(NavigationContext context) : base(context) {
    }

    public new async Task<Route> ReadAsync(int id) => await _set.Where(r => r.RouteId == id)
        .Include(r => r.FromLocation).Include(r => r.ToLocation).SingleOrDefaultAsync();

    public new async Task<List<Route>> ReadAsync() =>
        await _set.Include(r => r.FromLocation).Include(r => r.ToLocation).ToListAsync();
}