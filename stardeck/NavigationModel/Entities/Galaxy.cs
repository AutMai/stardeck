using System;
using System.Collections.Generic;

namespace NavigationModel.Entities
{
    public partial class Galaxy : Location
    {
        public Galaxy()
        {
            Planets = new HashSet<Planet>();
        }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}
