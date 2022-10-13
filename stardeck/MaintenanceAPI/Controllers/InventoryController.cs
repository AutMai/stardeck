using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceDTO.Create;
using MaintenanceDTO.Read;
using MaintenanceModel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceAPI.Controllers;

[ApiController]
[Route("/maintenance/inventory")]
public class InventoryController : AController<Inventory, CreateInventoryDTO, InventoryDTO>
{
    public InventoryController(IRepository<Inventory> repo) : base(repo)
    {
    }
}