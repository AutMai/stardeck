using System.Text.Json;
using EventBusConnection.Client;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDatatransfer.Controller.Create;
using NavigationDatatransfer.Controller.Read;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Entities;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/locations")]
public class LocationController : AController<Location, CreateLocationDto, LocationDto> {
    public LocationController(IRepository<Location> repo, IEventPublisher eventBusClient) : base(repo, eventBusClient) {
    }

    public override async Task<ActionResult<LocationDto>> ReadAsync(int id) {
        var res = await Repo.ReadAsync(id);

        return res switch {
            null => NotFound(),
            Planet p => Ok(p.Adapt<PlanetDto>()),
            Galaxy g => Ok(g.Adapt<GalaxyDto>()),
            _ => Ok(res)
        };
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<LocationDto>> ReadByNameAsync(string name) {
        var res = (await Repo.ReadAsync(l => l.Name == name)).SingleOrDefault();

        return res switch {
            null => NotFound(),
            Planet p => Ok(p.Adapt<PlanetDto>()),
            Galaxy g => Ok(g.Adapt<GalaxyDto>()),
            _ => Ok(res)
        };
    }

    [HttpPost("travelTo/{name}")]
    public async Task<ActionResult<LocationDto>> TravelToLocationAsync(string name) {
        var res = (await Repo.ReadAsync(l => l.Name == name)).SingleOrDefault();

        var message =
            JsonSerializer.Serialize(new ArrivedAtLocationEvent(EventType.ArrivedAtLocation.ToString(), name));
        EventBusClient.Publish(message);

        return Ok();
    }

    [HttpPost("depart")]
    public async Task<ActionResult<LocationDto>> DepartAsync(string name) {
        var res = (await Repo.ReadAsync(l => l.Name == name)).SingleOrDefault();

        var message =
            JsonSerializer.Serialize(new DepartedFromLocationEvent(EventType.DepartedFromLocation.ToString(), ""));
        EventBusClient.Publish(message);

        return Ok();
    }
}