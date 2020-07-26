using System;
using System.Collections.Generic;
using System.Linq;

namespace LibertyOrDeath.Domain.Entities
{
    public class Map
    {
        public Map(IEnumerable<Location> locations)
        {
            Locations = locations;
        }

        public IEnumerable<Location> Locations { get; }

        public IEnumerable<Location> GetAdjacentLocations(Location location)
        {
            if(location == null)
            {
                return new List<Location>();
            }

            return Locations.Where(x => location.AdjacentLocations.Any(adj => adj.Equals(x.Name)));
        }
    }
}
