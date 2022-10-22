using EventBusConnection;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;
using NavigationDTOs.Create;
using NavigationDTOs.Read;
using NavigationModel.Entities;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/galaxies")]
public class GalaxyController : AController<Galaxy, CreateGalaxyDto, GalaxyDto> {
    public GalaxyController(IRepository<Galaxy> repo, IEventBusClient eventBusClient) : base(repo, eventBusClient) {
    }
}