using System;
using System.Collections.Generic;

namespace MaintenanceModel.Entities
{
    public partial class Inventory
    {
        public int RessourceId { get; set; }
        public string Name { get; set; } = null!;
        public int Amount { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; } = null!;
    }
}
