using System;
using System.Collections.Generic;

namespace CrewModel.Entities
{
    public partial class Crew
    {
        public Crew()
        {
            Logbooks = new HashSet<Logbook>();
        }

        public int CrewMemberId { get; set; }
        public int Health { get; set; }

        public virtual Commander Commander { get; set; } = null!;
        public virtual Droid Droid { get; set; } = null!;
        public virtual Guard Guard { get; set; } = null!;
        public virtual Mechanic Mechanic { get; set; } = null!;
        public virtual ICollection<Logbook> Logbooks { get; set; }
    }
}
