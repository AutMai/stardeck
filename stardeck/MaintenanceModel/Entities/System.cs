using System;
using System.Collections.Generic;

namespace MaintenanceModel.Entities
{
    public partial class System
    {
        public int SystemId { get; set; }
        public string Name { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int ShipId { get; set; }
        
        public virtual ShipInfo Ship { get; set; } = null!;
        public virtual EStatus StatusNavigation { get; set; } = null!;
    }
}
