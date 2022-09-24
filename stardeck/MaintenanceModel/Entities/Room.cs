using System;
using System.Collections.Generic;

namespace MaintenanceModel.Entities
{
    public partial class Room
    {
        public Room()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int RoomId { get; set; }
        public string Name { get; set; } = null!;
        public int ShipId { get; set; }

        public virtual ShipInfo Ship { get; set; } = null!;
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
