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
}