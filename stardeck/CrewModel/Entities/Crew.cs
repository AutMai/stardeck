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
        public virtual ICollection<Logbook> Logbooks { get; set; }
    }
}
