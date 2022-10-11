using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceDTO.Create;
using MaintenanceDTO.Read;
using MaintenanceModel.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceAPI.Controllers;

[ApiController]
[Route("/maintenance/systems")]
public class SystemController : AController<MaintenanceModel.Entities.System, CreateASystemDTO, ASystemDTO>
{
    public SystemController(IRepository<MaintenanceModel.Entities.System> repo) : base(repo) {
    }

    public override async Task<ActionResult<ASystemDTO>> ReadAsync(int id) {
        var res = await _repo.ReadAsync(id);

        return res switch {
            null => NotFound(),
            EnergySystem e => Ok(e.Adapt<EnergySystemDTO>()),
            GravitationSystem g => Ok(g.Adapt<GravitationSystemDTO>()),
            LifeSupportSystem l => Ok(l.Adapt<LifeSupportSystemDTO>()),
            _ => Ok(res)
        };
    }
}