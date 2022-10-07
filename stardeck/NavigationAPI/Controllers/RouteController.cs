using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;
using NavigationDTOs.Create;
using NavigationDTOs.Read;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/routes")]
public class RouteController : AController<NavigationModel.Entities.Route, CreateRouteDto, RouteDto> {
    private IRouteRepository _routeRepository;

    public RouteController(IRepository<NavigationModel.Entities.Route> repo, IRouteRepository routeRepository) :
        base(repo) {
        _routeRepository = routeRepository;
    }

    public override async Task<ActionResult<List<RouteDto>>> ReadAsync() {
        var routes = await _routeRepository.ReadAsync();
        return routes.Select(g => g.Adapt<RouteDto>()).ToList();
    }

    public override async Task<ActionResult<RouteDto>> ReadAsync(int id) =>
        Ok((await _routeRepository.ReadAsync(id)).Adapt<RouteDto>());
}