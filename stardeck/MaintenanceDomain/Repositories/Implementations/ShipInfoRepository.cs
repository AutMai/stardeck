using MaintenanceModel.Configurations;
using MaintenanceModel.Entities;

namespace MaintenanceDomain.Repositories.Implementations;

public class ShipInfoRepository : ARepository<ShipInfo> {
    public ShipInfoRepository(MaintenanceContext context) : base(context) {
    }
}