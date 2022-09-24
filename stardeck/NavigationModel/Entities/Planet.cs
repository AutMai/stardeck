using System;
using System.Collections.Generic;

namespace NavigationModel.Entities
{
    public partial class Planet: Location
    {
        public sbyte IsExoplanet { get; set; }
        public int GalaxyId { get; set; }

        public virtual Galaxy Galaxy { get; set; } = null!;
    }
}
