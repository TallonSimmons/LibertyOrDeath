using System;
using LibertyOrDeath.Domain.Entities;
using LibertyOrDeath.Domain.Enums;

namespace LibertyOrDeath.Domain.Extensions
{
    public static class LocationExtensions
    {
        public static bool IsHighPriorityGarrisonLocation(this Location location)
        {
            return location.LocationType == LocationType.City
                && location.PatriotPresence.Exists
                && location.PatriotPresence.Unfortified
                && location.Control == Control.Rebellion
                && location.IsNotBlockaded;
        }

        public static bool IsLowPriorityGarrisonLocation(this Location location)
        {
            return location.LocationType == LocationType.City
                && location.PatriotPresence.Exists
                && location.PatriotPresence.Fortified
                && location.Control == Control.Rebellion
                && location.IsNotBlockaded;
        }

        public static bool IsValidGarrisonOriginLocation(this Location location)
        {
            return location.BritishPresence.Exists
                && location.BritishPresence.HasRegulars
                && location.IsNotBlockaded
                && (location.TotalRoyalistPresence - location.TotalRebellionPresence > 2
                || location.Population == 0
                || location.Opposition == Opposition.ActiveSupport);
        }
    }
}
