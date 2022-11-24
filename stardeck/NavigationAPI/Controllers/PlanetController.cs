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
[Route("/navigation/planets")]
public class PlanetController : AController<Planet, CreatePlanetDto, PlanetDto> {
    public PlanetController(IRepository<Planet> repo, IEventPublisher eventBusClient) : base(repo, eventBusClient) {
    }
}