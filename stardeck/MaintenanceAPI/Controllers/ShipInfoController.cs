using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceAPI.Controllers;

[ApiController]
[Route("/maintenance/shipinfo")]
public class ShipInfoController : AController<ShipInfo> {
    public ShipInfoController(IRepository<ShipInfo> repo) : base(repo) {
    }
}