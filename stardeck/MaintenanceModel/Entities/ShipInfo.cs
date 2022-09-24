using System;
using System.Collections.Generic;

namespace MaintenanceModel.Entities
{
    public partial class ShipInfo
    {
        public ShipInfo()
        {
            Rooms = new HashSet<Room>();
            Systems = new HashSet<System>();
        }

        public int ShipId { get; set; }
        public string Name { get; set; } = null!;
        public string CurrentLocation { get; set; } = null!;

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<System> Systems { get; set; }
    }
}
