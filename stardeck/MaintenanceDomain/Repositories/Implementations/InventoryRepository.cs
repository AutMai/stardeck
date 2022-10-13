using MaintenanceModel.Configurations;
using MaintenanceModel.Entities;

namespace MaintenanceDomain.Repositories.Implementations;

public class InventoryRepository : ARepository<Inventory>
{
    public InventoryRepository(MaintenanceContext context) : base(context)
    {
    }
}