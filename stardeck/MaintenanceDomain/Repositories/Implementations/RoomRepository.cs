using MaintenanceModel.Configurations;
using MaintenanceModel.Entities;

namespace MaintenanceDomain.Repositories.Implementations;

public class RoomRepository : ARepository<Room>
{
    public RoomRepository(MaintenanceContext context) : base(context)
    {
    }
}