using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;
using NavigationDTOs;
using NavigationDTOs.Create;
using NavigationDTOs.Read;
using NavigationModel.Entities;

namespace NavigationAPI.Controllers;

[ApiController]
[Route("/navigation/planets")]
public class PlanetController : AController<Planet, CreatePlanetDto, PlanetDto> {
    private IPlanetRepository _planetRepository;

    public PlanetController(IRepository<Planet> repo, IPlanetRepository planetRepository) : base(repo) {
        _planetRepository = planetRepository;
    }

    public override async Task<ActionResult<List<PlanetDto>>> ReadAsync() {
        var planets = await _planetRepository.ReadAsync();
        return planets.Select(g => g.Adapt<PlanetDto>()).ToList();
    }

    public override async Task<ActionResult<PlanetDto>> ReadAsync(int id) =>
        Ok((await _planetRepository.ReadAsync(id)).Adapt<PlanetDto>());
}