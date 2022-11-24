using EventBusConnection;
using EventBusConnection.Client;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDatatransfer.Controller.Create;
using NavigationDatatransfer.Controller.Read;
using NavigationDomain.Repositories.Interfaces;
using Route = NavigationModel.Entities.Route;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/routes")]
public class RouteController : AController<Route, CreateRouteDto, RouteDto> {
    public RouteController(IRepository<Route> repo, IEventPublisher eventBusClient) : base(repo, eventBusClient) {
    }
}