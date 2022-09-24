using System;
using System.Collections.Generic;

namespace MaintenanceModel.Entities
{
    public partial class EStatus
    {
        public EStatus()
        {
            Systems = new HashSet<System>();
        }

        public string Label { get; set; } = null!;

        public virtual ICollection<System> Systems { get; set; }
    }
}
