using System;
using System.Collections.Generic;
using System.Linq;
using LibertyOrDeath.Domain.Entities;
using LibertyOrDeath.Domain.Enums;
using LibertyOrDeath.Domain.Extensions;
using LibertyOrDeath.Common.Location;

namespace LibertyOrDeath.Domain.ValueTypes.British
{
    public class Garrison
    {
        public Garrison(Map map, Entities.British british)
        {
            var highPriorityDestinationLocations = map.Locations.Where(x => x.IsHighPriorityGarrisonLocation());
            var validOriginLocations = map.Locations.Where(x => x.IsValidGarrisonOriginLocation()).ToList();
            if (british.Resources < 2
                || british.Forces.NumberOfRegularsDeployed < 10
                || !highPriorityDestinationLocations.Any()
                || !validOriginLocations.Any())
            {
                Success = false;
                return;
            }

            var allDestinations = GetDestinations(map, highPriorityDestinationLocations);

            var locationsWherePiecesMoved = new List<Location>();
            var originLocation = validOriginLocations.Random();

            for (int i = 0; i < allDestinations.Count; i++)
            {
                var destinationLocation = allDestinations[i];
                if (originLocation.Id.Equals(destinationLocation.Id) && validOriginLocations.Count == 1)
                {
                    return;
                }

                if (originLocation.Id.Equals(destinationLocation.Id))
                {
                    originLocation = HandleOriginMatchingDestination(validOriginLocations, originLocation);
                }

                var piecesToPlace = validOriginLocations.Any();

                while (destinationLocation.Control != Control.British && piecesToPlace)
                {
                    if(originLocation == null && validOriginLocations.Any())
                    {
                        originLocation = validOriginLocations.Random();
                    }
                    else if(originLocation == null && !validOriginLocations.Any())
                    {
                        break;
                    }
                    MoveRegulars(originLocation, destinationLocation);

                    if (!originLocation.IsValidGarrisonOriginLocation())
                    {
                        validOriginLocations.Remove(originLocation);
                        originLocation = validOriginLocations.Random();
                    }
                }

                var noMoreOriginSpaces = !validOriginLocations.Any();
                var noMoreDestinationSpaces = i == allDestinations.Count - 1;
                if (noMoreOriginSpaces || noMoreDestinationSpaces)
                {
                    Success = locationsWherePiecesMoved.Any();
                    var finalLocations = new List<Location>();
                    finalLocations.AddRange(map.Locations
                        .Where(x => locationsWherePiecesMoved
                        .Any(y => y.Id != x.Id)));
                    finalLocations.AddRange(locationsWherePiecesMoved);
                    MapAfterCommand = new Map(finalLocations);
                    ActivateMilitia();
                    DisperseRebellionPieces();
                    return;
                }
            }
        }

        public bool Success { get; private set; }
        public Map MapAfterCommand { get; }
        public List<BritishMovement> CommandMovements { get; private set; } = new List<BritishMovement>();

        private void ActivateMilitia()
        {
            var eligibleLocations = MapAfterCommand.Locations
                .Where(x => x.IsNotBlockaded
                && (x.BritishPresence.HasRegulars || x.BritishPresence.HasTories)
                && x.PatriotPresence.HasUndergroundMilita
                && x.LocationType == LocationType.City);

            foreach (var location in eligibleLocations)
            {
                var totalPossibleActivations = Math.Round((location.BritishPresence.Regulars + location.BritishPresence.Tories) / 3m);
                for (int i = 0; i < totalPossibleActivations; i++)
                {
                    if (location.PatriotPresence.HasUndergroundMilita)
                    {
                        var activationSuccess = location.PatriotPresence.TryActivateMilitia();

                        if (!activationSuccess)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void DisperseRebellionPieces()
        {
            var highestPriorityDispersalLocation = MapAfterCommand?.Locations?
                    .OrderBy(x => x.TotalRebellionPresence)
                    .FirstOrDefault(x => x.IsNotBlockaded
                        && x.PatriotPresence.Unfortified
                        && x.Control == Control.British
                        && x.LocationType == LocationType.City);

            var highestPriorityAdjacentLocation = MapAfterCommand?
                .GetAdjacentLocations(highestPriorityDispersalLocation)
                .OrderByDescending(x => x.Opposition)
                .ThenByDescending(x => x.Population)
                .FirstOrDefault();


            if (highestPriorityDispersalLocation == null || highestPriorityAdjacentLocation == null)
            {
                return;
            }

            highestPriorityAdjacentLocation.PatriotPresence.Continentals = highestPriorityDispersalLocation.PatriotPresence.Continentals;
            highestPriorityAdjacentLocation.PatriotPresence.UnderGroundMilitia = highestPriorityDispersalLocation.PatriotPresence.UnderGroundMilitia;
            highestPriorityAdjacentLocation.PatriotPresence.ActiveMilitia = highestPriorityDispersalLocation.PatriotPresence.ActiveMilitia;

            highestPriorityDispersalLocation.PatriotPresence.Continentals = 0;
            highestPriorityDispersalLocation.PatriotPresence.UnderGroundMilitia = 0;
            highestPriorityDispersalLocation.PatriotPresence.ActiveMilitia = 0;
        }

        private static Location HandleOriginMatchingDestination(List<Location> validOriginLocations, Location originLocation)
        {
            validOriginLocations.Remove(originLocation);

            return validOriginLocations.Random();
        }


        private void MoveRegulars(Location originLocation, Location destinationLocation)
        {
            originLocation.BritishPresence.Regulars--;
            destinationLocation.BritishPresence.Regulars++;
            var existingMovement = CommandMovements
                .FirstOrDefault(x => x.OriginLocation.Name.Equals(originLocation.Name)
                            && x.DestinationLocation.Name.Equals(destinationLocation.Name));

            if (existingMovement != null)
            {
                existingMovement.RegularsMoved++;
            }
            else
            {
                CommandMovements.Add(new BritishMovement(originLocation, destinationLocation, 1, 0));
            }
        }

        private static List<Location> GetDestinations(Map map, IEnumerable<Location> highPriorityDestinationLocations)
        {
            var highPriorityDestinations = highPriorityDestinationLocations
                                .OrderBy(x => x.TotalRebellionPresence);
            var lowPriorityDestinations = map.Locations.Where(x => x.IsLowPriorityGarrisonLocation());

            var allDestinations = new List<Location>();
            allDestinations.AddRange(highPriorityDestinations);
            if(!highPriorityDestinations.Any(x => x.Name.Equals(LocationNames.NewYorkCity)))
            {
                allDestinations.Add(map.Locations.FirstOrDefault(x => x.Name.Equals(LocationNames.NewYorkCity)));
            }
            allDestinations.AddRange(lowPriorityDestinations);
            return allDestinations;
        }

    }
}
