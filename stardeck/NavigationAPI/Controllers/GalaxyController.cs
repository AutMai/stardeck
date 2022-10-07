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
    private readonly IGalaxyRepository _galaxyRepository;

    public GalaxyController(IRepository<Galaxy> repo, IGalaxyRepository galaxyRepository) : base(repo) {
        _galaxyRepository = galaxyRepository;
    }

    public override async Task<ActionResult<List<GalaxyDto>>> ReadAsync() {
        var galaxies = await _galaxyRepository.ReadAsync();
        return galaxies.Select(g => g.Adapt<GalaxyDto>()).ToList();
    }

    public override async Task<ActionResult<GalaxyDto>> ReadAsync(int id) =>
        Ok((await _galaxyRepository.ReadAsync(id)).Adapt<GalaxyDto>());
}