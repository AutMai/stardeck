using NavigationModel.Entities;

namespace NavigationDomain.Repositories.Interfaces;

public interface IPlanetRepository : IRepository<Planet> {
    new Task<Planet> ReadAsync(int id);
    new Task<List<Planet>> ReadAsync();
}