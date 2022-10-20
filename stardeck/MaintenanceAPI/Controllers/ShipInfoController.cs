using System.Text;
using EventBusConnection;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceDTO.Create;
using MaintenanceDTO.Read;
using MaintenanceModel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceAPI.Controllers;

[ApiController]
[Route("/maintenance/shipinfo")]
public class ShipInfoController : AController<ShipInfo, CreateShipInfoDTO, ShipInfoDTO> {
    public ShipInfoController(IRepository<ShipInfo> repo) : base(repo)
    {
    }
    
    [HttpGet("/test")]
    public async Task<ActionResult<IEnumerable<ShipInfoDTO>>> Get() {
        var c = new Connector();
        c.Init();
        var model = c.GetModel();
        
        var properties = model.CreateBasicProperties();
        properties.Persistent = false;
        
        byte[] messagebuffer = Encoding.Default.GetBytes("Direct Message");

        model.BasicPublish("stardeckExchange", "", false, properties, messagebuffer);
        return Ok(await _repo.ReadAsync(1));
    }
}