using System.Text.Json;
using System.Threading.Tasks;
using EventBusConnection;
using EventBusConnection.EventsProcessing;
using EventBusConnection.EventsProcessing.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceDTO.Create;
using MaintenanceDTO.Read;
using MaintenanceModel.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceAPI.Controllers;

[ApiController]
[Route("/maintenance/systems")]
public class SystemController : AController<MaintenanceModel.Entities.System, CreateASystemDTO, ASystemDTO> {
    private readonly IEventBusClient _eventBusClient;

    public SystemController(IRepository<MaintenanceModel.Entities.System> repo, IEventBusClient eventBusClient) : base(
        repo, eventBusClient) {
        _eventBusClient = eventBusClient;
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

    [HttpPut("{id:int}/status/{status}")]
    public async Task<ActionResult> UpdateStatusAsync(int id, string status) {
        var system = await _repo.ReadAsync(id);
        if (system == null) return NotFound();
        system.Status = status;
        var systemDto = system.Adapt<ASystemDTO>();
        await base.UpdateAsync(id, systemDto);
        if (status == "Damaged") {
            var message =
                JsonSerializer.Serialize(new SystemDamagedEvent(EventType.SystemDamaged.ToString(), systemDto));
            _eventBusClient.Publish(message);
        }

        return Ok();
    }
}