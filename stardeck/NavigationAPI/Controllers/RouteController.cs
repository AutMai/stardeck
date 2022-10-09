using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;
using NavigationDTOs.Create;
using NavigationDTOs.Read;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/routes")]
public class RouteController : AController<NavigationModel.Entities.Route, CreateRouteDto, RouteDto> {
    public RouteController(IRepository<NavigationModel.Entities.Route> repo) : base(repo) {
    }
}