using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/routes")]
public class RouteController : AController<NavigationModel.Entities.Route> {
    public RouteController(IRepository<NavigationModel.Entities.Route> repo) : base(repo) {
    }
}