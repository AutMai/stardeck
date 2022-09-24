using System;
using System.Collections.Generic;

namespace CrewModel.Entities
{
    public partial class Mechanic
    {
        public int CrewMemberId { get; set; }

        public virtual Crew CrewMember { get; set; } = null!;
    }
}
