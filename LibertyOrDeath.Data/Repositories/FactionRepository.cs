using System.Collections.Generic;
using LibertyOrDeath.Domain.Entities;
using LibertyOrDeath.Domain.Repositories;

namespace LibertyOrDeath.Data.Repositories
{
    public class FactionRepository : IFactionRepository
    {

        public IEnumerable<Faction> GetAll()
        {
            return new List<Faction>();
        }
    }
}
