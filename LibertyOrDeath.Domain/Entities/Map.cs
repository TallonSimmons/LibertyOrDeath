using System;
using System.Collections.Generic;

namespace LibertyOrDeath.Domain.Entities
{
    public class Map
    {
        public Map(IEnumerable<Location> locations)
        {
            Locations = locations;
        }

        public IEnumerable<Location> Locations { get; }
    }
}
