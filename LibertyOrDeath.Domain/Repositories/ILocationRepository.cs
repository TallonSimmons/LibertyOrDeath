using System.Collections.Generic;
using LibertyOrDeath.Domain.Entities;

namespace LibertyOrDeath.Domain.Repositories
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetShortScenarioLocations();
        IEnumerable<Location> GetMediumScenarioLocations();
        IEnumerable<Location> GetLongScenarioLocations();
    }
}
