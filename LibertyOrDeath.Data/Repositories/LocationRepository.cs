using System;
using System.Collections.Generic;
using LibertyOrDeath.Domain.Entities;
using LibertyOrDeath.Domain.Repositories;

namespace LibertyOrDeath.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public IEnumerable<Location> GetAll()
        {
            return new List<Location>();
        }
    }
}
