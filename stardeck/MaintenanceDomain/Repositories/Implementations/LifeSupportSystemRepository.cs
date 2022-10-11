using MaintenanceModel.Configurations;
using MaintenanceModel.Entities;

namespace MaintenanceDomain.Repositories.Implementations;

public class LifeSupportSystemRepository : ARepository<LifeSupportSystem>
{
    public LifeSupportSystemRepository(MaintenanceContext context) : base(context)
    {
    }
}