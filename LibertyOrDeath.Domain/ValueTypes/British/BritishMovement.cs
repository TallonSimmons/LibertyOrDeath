using System;
using LibertyOrDeath.Domain.Entities;

namespace LibertyOrDeath.Domain.ValueTypes.British
{
    public class BritishMovement
    {
        public BritishMovement(Location originLocation, Location destinationLocation, int regularsMoved, int toriesMoved)
        {
            if ((regularsMoved == 0 && toriesMoved == 0) || (regularsMoved < 0 || toriesMoved < 0))
            {
                throw new ArgumentOutOfRangeException();
            }

            OriginLocation = originLocation;
            DestinationLocation = destinationLocation;
            RegularsMoved = regularsMoved;
            ToriesMoved = toriesMoved;
        }

        public Location OriginLocation { get; }
        public Location DestinationLocation { get; }
        public int RegularsMoved { get; set; }
        public int ToriesMoved { get; set; }
        public string Description => $"British moved {GetRegularsMovementDescription()}{GetAndSymbolIfBothMoved()}{GetToriesMovementDescription()} from {OriginLocation.Name} to {DestinationLocation.Name}";

        private string GetRegularsMovementDescription()
        {
            return RegularsMoved > 0 ? $"{RegularsMoved} regulars" : string.Empty;
        }

        private string GetAndSymbolIfBothMoved()
        {
            return RegularsMoved > 0 && ToriesMoved > 0 ? " & " : string.Empty;
        }

        private string GetToriesMovementDescription()
        {
            return ToriesMoved > 0 ? $"{ToriesMoved} tories" : string.Empty;
        }
    }
}
