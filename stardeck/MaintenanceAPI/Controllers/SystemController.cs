using System.Text.Json;
using System.Threading.Tasks;
using EventBusConnection;
using EventBusConnection.Client;
using EventBusConnection.Event.Events;
using MaintenanceDatatransfer.Controller.Create;
using MaintenanceDatatransfer.Controller.Read;
using MaintenanceDomain.Repositories.Interfaces; 
using MaintenanceModel.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceAPI.Controllers;

[ApiController]
[Route("/maintenance/systems")]
public class SystemController : AController<MaintenanceModel.Entities.System, CreateASystemDTO, ASystemDTO> {
    private readonly IEventPublisher _eventBusClient;

    public SystemController(IRepository<MaintenanceModel.Entities.System> repo, IEventPublisher eventBusClient) : base(
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
        await base.UpdateAsync(id, system.Adapt<ASystemDTO>());
        if (status == "Damaged") {
            var message = JsonSerializer.Serialize(new SystemDamagedEvent(system.SystemId));
            _eventBusClient.Publish(message);
        }
        return Ok();
    }
}