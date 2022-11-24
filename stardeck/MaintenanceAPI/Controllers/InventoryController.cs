using EventBusConnection;
using EventBusConnection.Client;
using MaintenanceDatatransfer.Controller.Create;
using MaintenanceDatatransfer.Controller.Read;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceAPI.Controllers;

[ApiController]
[Route("/maintenance/inventory")]
public class InventoryController : AController<Inventory, CreateInventoryDTO, InventoryDTO>
{
    public InventoryController(IRepository<Inventory> repo, IEventPublisher eventBusClient) : base(repo, eventBusClient)
    {
    }
}