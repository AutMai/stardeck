using MaintenanceModel.Configurations;

namespace MaintenanceDomain.Repositories.Implementations;

public class SystemRepository : ARepository<MaintenanceModel.Entities.System>
{
    public SystemRepository(MaintenanceContext context) : base(context)
    {
    }
}