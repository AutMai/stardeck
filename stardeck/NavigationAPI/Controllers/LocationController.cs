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

    [HttpGet("{name}")]
    public async Task<ActionResult<PlanetDto>> GetLocation(string name) {
        var res = (await _repo.ReadAsync(l => l.Name == name)).SingleOrDefault();
        if (res is Planet p) {
            var dto = p.Adapt<PlanetDto>();
            return Ok(dto);
        }
        else if (res is Galaxy g) {
            var dto = g.Adapt<GalaxyDto>();
            return Ok(dto);
        }
        else {
            return NotFound();
        }
    }
}