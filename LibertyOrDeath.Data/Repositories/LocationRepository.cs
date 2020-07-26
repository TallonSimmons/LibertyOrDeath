using System;
using System.Collections.Generic;
using LibertyOrDeath.Common.Location;
using LibertyOrDeath.Domain.Entities;
using LibertyOrDeath.Domain.Repositories;
using LibertyOrDeath.Domain.ValueTypes.Patriot;
using LibertyOrDeath.Domain.ValueTypes.French;
using LibertyOrDeath.Domain.ValueTypes.Indian;
using LibertyOrDeath.Domain.ValueTypes.British;
using LibertyOrDeath.Domain.Enums;
using System.Linq;

namespace LibertyOrDeath.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public IEnumerable<Location> GetLongScenarioLocations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetMediumScenarioLocations()
        {
            return MediumScenario.Locations;
        }

        public IEnumerable<Location> GetShortScenarioLocations()
        {
            throw new NotImplementedException();
        }
    }

    internal class MediumScenario
    {
        static Location MediumQuebec = new Location(
                LocationNames.Quebec,
                0,
                new PatriotPresence(1, 0, 0, 0, 0),
                new BritishPresence(1, 1, 1),
                new FrenchPresence(0, 0),
                new IndianPresence(1, 0, 1, 0),
                Opposition.Neutral,
                LocationType.Reserve,
                new List<string>
                {
                    LocationNames.QuebecCity,
                    LocationNames.Northwest,
                    LocationNames.Southwest
                });
        static Location MediumQuebecCity = new Location(
               LocationNames.QuebecCity,
               1,
               new PatriotPresence(1, 0, 0, 0, 0),
               new BritishPresence(1, 1, 1),
               new FrenchPresence(0, 0),
               new IndianPresence(1, 0, 1, 0),
               Opposition.Neutral,
               LocationType.City,
               new List<string>
               {
                   LocationNames.Quebec,
                   LocationNames.NewHampshire
               });
        static Location MediumBoston = new Location(
                       LocationNames.Boston,
                       1,
                       new PatriotPresence(0, 0, 0, 0, 0),
                       new BritishPresence(0, 0, 0),
                       new FrenchPresence(0, 0),
                       new IndianPresence(0, 0, 0, 0),
                       Opposition.PassiveOpposition,
                       LocationType.City,
                       new List<string>
                       {
                           LocationNames.ConnecticutRhodeIsland,
                           LocationNames.Massachussets
                       });
        static Location MediumNewYorkCity = new Location(
                       LocationNames.NewYorkCity,
                       2,
                       new PatriotPresence(0, 0, 1, 0, 0),
                       new BritishPresence(6, 0, 1),
                       new FrenchPresence(0, 0),
                       new IndianPresence(0, 0, 0, 0),
                       Opposition.PassiveSupport,
                       LocationType.City,
                       new List<string>
                       {
                            LocationNames.NewYork,
                            LocationNames.NewJersey
                       });
        static Location MediumPhiladelphia = new Location(
                       LocationNames.Philadelphia,
                       1,
                       new PatriotPresence(0, 0, 1, 0, 0),
                       new BritishPresence(0, 0, 0),
                       new FrenchPresence(0, 0),
                       new IndianPresence(0, 0, 0, 0),
                       Opposition.Neutral,
                       LocationType.City,
                       new List<string>
                       {
                           LocationNames.NewJersey,
                           LocationNames.MarylandDelaware,
                           LocationNames.Pennsylvania
                       });
        static Location MediumSavannah = new Location(
               LocationNames.Savannah,
               1,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.City,
               new List<string>
               {
                   LocationNames.Georgia,
                   LocationNames.SouthCarolina
               });
        static Location MediumNorfolk = new Location(
               LocationNames.Norfolk,
               1,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.City,
               new List<string>
               {
                   LocationNames.Virginia,
                   LocationNames.NorthCarolina
               });
        static Location MediumCharlesTown = new Location(
               LocationNames.CharlesTown,
               1,
               new PatriotPresence(0, 0, 2, 1, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.City,
               new List<string>
               {
                   LocationNames.SouthCarolina,
                   LocationNames.NorthCarolina
               });
        static Location MediumNorthWest = new Location(
               LocationNames.Northwest,
               0,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(1, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Reserve,
               new List<string>
               {
                   LocationNames.Quebec,
                   LocationNames.Southwest,
                   LocationNames.Virginia,
                   LocationNames.Pennsylvania,
                   LocationNames.NewYork
               });
        static Location MediumSouthWest = new Location(
               LocationNames.Southwest,
               0,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(1, 0, 1, 0),
               Opposition.Neutral,
               LocationType.Reserve,
               new List<string>
               {
                   LocationNames.Quebec,
                   LocationNames.Northwest,
                   LocationNames.Virginia,
                   LocationNames.NorthCarolina,
                   LocationNames.SouthCarolina,
                   LocationNames.Georgia,
                   LocationNames.Florida
               });
        static Location MediumFlorida = new Location(
               LocationNames.Florida,
               0,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(1, 0, 1),
               new FrenchPresence(0, 0),
               new IndianPresence(2, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Reserve,
               new List<string>
               {
                    LocationNames.Georgia,
                    LocationNames.Southwest
               });
        static Location MediumMassachusetts = new Location(
               LocationNames.Massachussets,
               2,
               new PatriotPresence(1, 0, 1, 1, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.ActiveOpposition,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.NewHampshire,
                   LocationNames.Boston,
                   LocationNames.ConnecticutRhodeIsland,
                   LocationNames.NewYork
               });
        static Location MediumMarylandDelaware = new Location(
               LocationNames.MarylandDelaware,
               2,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.Philadelphia,
                   LocationNames.Virginia,
                   LocationNames.Pennsylvania
               });
        static Location MediumConnecticutRhodeIsland = new Location(
               LocationNames.ConnecticutRhodeIsland,
               2,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.Boston,
                   LocationNames.Massachussets,
                   LocationNames.NewYork
               });
        static Location MediumNewYork = new Location(
               LocationNames.NewYork,
               2,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 2, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.ActiveOpposition,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.Quebec,
                   LocationNames.Northwest,
                   LocationNames.Pennsylvania,
                   LocationNames.NewJersey,
                   LocationNames.NewYorkCity,
                   LocationNames.ConnecticutRhodeIsland,
                   LocationNames.Massachussets,
                   LocationNames.NewHampshire
               });
        static Location MediumVirginia = new Location(
               LocationNames.Virginia,
               2,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 2, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.Northwest,
                   LocationNames.Southwest,
                   LocationNames.Norfolk,
                   LocationNames.MarylandDelaware,
                   LocationNames.NorthCarolina
               });
        static Location MediumNorthCarolina = new Location(
               LocationNames.NorthCarolina,
               2,
               new PatriotPresence(1, 0, 1, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(1, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.Norfolk,
                   LocationNames.Virginia,
                   LocationNames.SouthCarolina,
                   LocationNames.CharlesTown,
                   LocationNames.Southwest
               });
        static Location MediumSouthCarolina = new Location(
               LocationNames.SouthCarolina,
               2,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 2, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.NorthCarolina,
                   LocationNames.CharlesTown,
                   LocationNames.Savannah,
                   LocationNames.Georgia,
                   LocationNames.Southwest
               });
        static Location MediumGeorgia = new Location(
               LocationNames.Georgia,
               1,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 2, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.SouthCarolina,
                   LocationNames.Savannah,
                   LocationNames.Florida,
                   LocationNames.Southwest
               });
        static Location MediumNewJersey = new Location(
               LocationNames.NewJersey,
               1,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.Pennsylvania,
                   LocationNames.Philadelphia,
                   LocationNames.NewYork,
                   LocationNames.NewYorkCity
               });
        static Location MediumNewHampshire = new Location(
               LocationNames.NewHampshire,
               1,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.Quebec,
                   LocationNames.QuebecCity,
                   LocationNames.Massachussets
               });
        static Location MediumPennsylvania = new Location(
               LocationNames.Pennsylvania,
               1,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.Colony,
               new List<string>
               {
                   LocationNames.Northwest,
                   LocationNames.NewYork,
                   LocationNames.Philadelphia,
                   LocationNames.MarylandDelaware
               });
        static Location MediumWestIndies = new Location(
               LocationNames.WestIndies,
               0,
               new PatriotPresence(0, 0, 0, 0, 0),
               new BritishPresence(0, 0, 0),
               new FrenchPresence(0, 0, 2),
               new IndianPresence(0, 0, 0, 0),
               Opposition.Neutral,
               LocationType.WestIndies,
               new List<string>
               {
               });

        static internal List<Location> Locations =
               new List<Location>
               {
                     MediumBoston,
                     MediumCharlesTown,
                     MediumConnecticutRhodeIsland,
                     MediumFlorida,
                     MediumGeorgia,
                     MediumMarylandDelaware,
                     MediumMassachusetts,
                     MediumNewHampshire,
                     MediumNewJersey,
                     MediumNewYork,
                     MediumNewYorkCity,
                     MediumNorfolk,
                     MediumNorthCarolina,
                     MediumNorthWest,
                     MediumPennsylvania,
                     MediumPhiladelphia,
                     MediumQuebec,
                     MediumQuebecCity,
                     MediumSavannah,
                     MediumSouthCarolina,
                     MediumSouthWest,
                     MediumVirginia,
                     MediumWestIndies
               };
    }
}
