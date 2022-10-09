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
    public PlanetController(IRepository<Planet> repo) : base(repo) {
    }
}