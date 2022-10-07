using NavigationModel.Entities;

namespace NavigationDomain.Repositories.Interfaces;

public interface IGalaxyRepository : IRepository<Galaxy> {
    new Task<Galaxy> ReadAsync(int id);
    new Task<List<Galaxy>> ReadAsync();
}