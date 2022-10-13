using MaintenanceModel.Configurations;
using MaintenanceModel.Entities;

namespace MaintenanceDomain.Repositories.Implementations;

public class EnergySystemRepository : ARepository<EnergySystem>
{
    public EnergySystemRepository(MaintenanceContext context) : base(context)
    {
    }
}