using Xunit;
using LibertyOrDeath.Domain.Entities;
using LibertyOrDeath.Domain.ValueTypes.Patriot;
using LibertyOrDeath.Domain.ValueTypes.British;
using System.Collections.Generic;
using LibertyOrDeath.Domain.ValueTypes.French;
using LibertyOrDeath.Domain.ValueTypes.Indian;
using LibertyOrDeath.Domain.Enums;
using System.Linq;

namespace LibertyOrDeath.Tests.British
{
    public class GarrisonShould
    {
        [Fact]
        public void MovePiecesWhenGarrisonPossible()
        {

            var map = new Map(GetTestLocations());
            var british = new Domain.Entities.British(1, "British", 3, new BritishForces(5, 5, 4, 0, 0));
            var garrison = new Garrison(map, british);

            var updatedNyc = garrison.MapAfterCommand.Locations.FirstOrDefault(x => x.Name.Equals("New York City"));
            var updatedQuebecCity = garrison.MapAfterCommand.Locations.FirstOrDefault(x => x.Name.Equals("Quebec City"));

            Assert.True(updatedNyc.BritishPresence.Regulars == 5);
        }

        [Fact]
        public void DisperseProperly()
        {
            var map = new Map(GetTestLocations());
            var british = new Domain.Entities.British(1, "British", 3, new BritishForces(5, 5, 4, 0, 0));
            var garrison = new Garrison(map, british);

            var updatedQuebec = garrison.MapAfterCommand.Locations.FirstOrDefault(x => x.Name.Equals("Quebec"));

            Assert.True(updatedQuebec.PatriotPresence.TotalPieces == 3);
        }

        [Fact]
        public void ActivateUndergroundMilitiaProperly()
        {
            var map = new Map(GetTestLocations());
            var british = new Domain.Entities.British(1, "British", 3, new BritishForces(5, 5, 4, 0, 0));
            var garrison = new Garrison(map, british);

            var updatedQuebec = garrison.MapAfterCommand.Locations.FirstOrDefault(x => x.Name.Equals("Quebec"));

            Assert.True(updatedQuebec.PatriotPresence.ActiveMilitia == 2);

        }

        private List<Location> GetTestLocations()
        {

            var newYork = new Location(
                    "New York",
                    2,
                    new PatriotPresence(0, 0, 0, 0, 0),
                    new BritishPresence(7, 0, 0),
                    new FrenchPresence(0, 0),
                    new IndianPresence(0, 0, 0, 0),
                    Opposition.ActiveOpposition,
                    LocationType.Colony,
                    new List<Location>());

            var newJersey = new Location(
                    "New Jersey",
                    1,
                    new PatriotPresence(0, 0, 0, 0, 0),
                    new BritishPresence(7, 0, 0),
                    new FrenchPresence(0, 0),
                    new IndianPresence(0, 0, 0, 0),
                    Opposition.ActiveOpposition,
                    LocationType.Colony,
                    new List<Location>());

            var newHampshire = new Location(
                    "New Hampshire",
                    1,
                    new PatriotPresence(0, 0, 0, 0, 0),
                    new BritishPresence(7, 0, 0),
                    new FrenchPresence(0, 0),
                    new IndianPresence(0, 0, 0, 0),
                    Opposition.PassiveOpposition,
                    LocationType.Colony,
                    new List<Location>());

            var quebec = new Location(
                    "Quebec",
                    1,
                    new PatriotPresence(0, 0, 0, 0, 0),
                    new BritishPresence(7, 0, 0),
                    new FrenchPresence(0, 0),
                    new IndianPresence(0, 0, 0, 0),
                    Opposition.ActiveOpposition,
                    LocationType.Colony,
                    new List<Location>());

            var nyc = new Location(
                    "New York City",
                    2,
                    new PatriotPresence(2, 0, 2, 0, 0),
                    new BritishPresence(0, 0, 0),
                    new FrenchPresence(0, 0),
                    new IndianPresence(0, 0, 0, 0),
                    Opposition.Neutral,
                    LocationType.City,
                    new List<Location> { newYork, newJersey });

            var qc = new Location(
                    "Quebec City",
                    2,
                    new PatriotPresence(3, 0, 0, 0, 0),
                    new BritishPresence(7, 0, 0),
                    new FrenchPresence(0, 0),
                    new IndianPresence(0, 0, 0, 0),
                    Opposition.Neutral,
                    LocationType.City,
                    new List<Location> { newHampshire, quebec });

            var locations = new List<Location>
            {
                nyc,
                qc,
                newHampshire,
                newJersey,
                quebec,
                newYork
            };

            return locations;
        }
    }
}
