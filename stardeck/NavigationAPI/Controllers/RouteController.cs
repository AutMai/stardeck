using EventBusConnection;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;
using NavigationDTOs.Create;
using NavigationDTOs.Read;
using Route = NavigationModel.Entities.Route;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/routes")]
public class RouteController : AController<NavigationModel.Entities.Route, CreateRouteDto, RouteDto> {
    public RouteController(IRepository<Route> repo, IEventBusClient eventBusClient) : base(repo, eventBusClient) {
    }
}