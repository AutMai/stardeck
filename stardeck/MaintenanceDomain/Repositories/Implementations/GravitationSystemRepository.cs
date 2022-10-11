using MaintenanceModel.Configurations;
using MaintenanceModel.Entities;

namespace MaintenanceDomain.Repositories.Implementations;

public class GravitationSystemRepository : ARepository<GravitationSystem>
{
    public GravitationSystemRepository(MaintenanceContext context) : base(context)
    {
    }
}