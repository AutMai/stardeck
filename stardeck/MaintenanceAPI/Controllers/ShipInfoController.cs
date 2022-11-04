using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EventBusConnection;
using EventBusConnection.EventsProcessing;
using EventBusConnection.EventsProcessing.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceDTO.Create;
using MaintenanceDTO.Read;
using MaintenanceModel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceAPI.Controllers;

[ApiController]
[Route("/maintenance/shipinfo")]
public class ShipInfoController : AController<ShipInfo, CreateShipInfoDTO, ShipInfoDTO> {
    private readonly IEventBusClient _eventBusClient;

    public ShipInfoController(IRepository<ShipInfo> repo, IEventBusClient eventBusClient) : base(repo, eventBusClient) {
        _eventBusClient = eventBusClient;
    }

    [HttpPost("/test2")]
    public async Task<ActionResult<ShipInfo>> Get2(string si) {
        var message = JsonSerializer.Serialize(si);
        _eventBusClient.Publish(message);
        return Ok(si);
    }
    
    
}