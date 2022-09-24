using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Entities;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/locations")]
public class LocationController : AController<Location> {
    public LocationController(IRepository<Location> repo) : base(repo) {
    }
    
    [HttpGet("{name}")]
    public async Task<ActionResult<Planet>> GetLocation(string name) {
        var res = await _repo.ReadAsync(l => l.Name == name);
        if (res.IsNullOrEmpty()) return NotFound();
        return Ok(res.First());
    }
}