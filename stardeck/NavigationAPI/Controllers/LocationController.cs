using Castle.Core.Internal;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;
using NavigationDTOs;
using NavigationDTOs.Create;
using NavigationDTOs.Read;
using NavigationModel.Entities;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/locations")]
public class LocationController : AController<Location, CreateLocationDto, LocationDto> {
    public LocationController(IRepository<Location> repo) : base(repo) {
    }

    public override async Task<ActionResult<LocationDto>> ReadAsync(int id) {
        var res = await _repo.ReadAsync(id);

        return res switch {
            null => NotFound(),
            Planet p => Ok(p.Adapt<PlanetDto>()),
            Galaxy g => Ok(g.Adapt<GalaxyDto>()),
            _ => Ok(res)
        };
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<LocationDto>> ReadByNameAsync(string name) {
        var res = (await _repo.ReadAsync(l => l.Name == name)).SingleOrDefault();

        return res switch {
            null => NotFound(),
            Planet p => Ok(p.Adapt<PlanetDto>()),
            Galaxy g => Ok(g.Adapt<GalaxyDto>()),
            _ => Ok(res)
        };
    }
}