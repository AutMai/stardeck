using NavigationModel.Entities;

namespace NavigationDomain.Repositories.Interfaces;

public interface IRouteRepository : IRepository<Route> {
    new Task<Route> ReadAsync(int id);
    new Task<List<Route>> ReadAsync();
}