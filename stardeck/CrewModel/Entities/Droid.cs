using System;
using System.Collections.Generic;

namespace CrewModel.Entities
{
    public partial class Droid
    {
        public int CrewCrewMemberId { get; set; }

        public virtual Crew CrewCrewMember { get; set; } = null!;
    }
}
