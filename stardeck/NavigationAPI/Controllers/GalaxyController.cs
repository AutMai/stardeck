using EventBusConnection;
using EventBusConnection.Client;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDatatransfer.Controller.Create;
using NavigationDatatransfer.Controller.Read;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Entities;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/galaxies")]
public class GalaxyController : AController<Galaxy, CreateGalaxyDto, GalaxyDto> {
    public GalaxyController(IRepository<Galaxy> repo, IEventPublisher eventBusClient) : base(repo, eventBusClient) {
    }
}