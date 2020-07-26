using LibertyOrDeath.Domain.Enums;
using LibertyOrDeath.Domain.ValueTypes.Patriot;
using LibertyOrDeath.Domain.ValueTypes.British;
using LibertyOrDeath.Domain.ValueTypes.French;
using LibertyOrDeath.Domain.ValueTypes.Indian;
using System.Collections.Generic;

namespace LibertyOrDeath.Domain.Entities
{
    public class Location
    {
        public Location(string name, int population, PatriotPresence patriotPresence, BritishPresence britishPresence, FrenchPresence frenchPresence, IndianPresence indianPresence, Opposition opposition, LocationType locationType, IEnumerable<string> adjacentLocations)
        {
            Name = name;
            Population = population;
            PatriotPresence = patriotPresence;
            BritishPresence = britishPresence;
            FrenchPresence = frenchPresence;
            IndianPresence = indianPresence;
            Opposition = opposition;
            LocationType = locationType;
            AdjacentLocations = adjacentLocations;
        }

        public string Id => Name;
        public string Name { get; }
        public int Population { get; }
        public PatriotPresence PatriotPresence { get; }
        public BritishPresence BritishPresence { get; }
        public FrenchPresence FrenchPresence { get; }
        public IndianPresence IndianPresence { get; }
        public Opposition Opposition { get; }
        public LocationType LocationType { get; }
        public IEnumerable<string> AdjacentLocations { get; }
        public Control Control
        {
            get
            {

                if (BritishPresence.Exists && TotalRoyalistPresence > TotalRebellionPresence)
                {
                    return Control.British;
                }
                else if (TotalRebellionPresence > TotalRoyalistPresence)
                {
                    return Control.Rebellion;
                }

                return Control.Neutral;
            }
        }
        public bool IsNotBlockaded => !FrenchPresence.BlockadePresent;
        public bool Blockaded => FrenchPresence.BlockadePresent;
        public int TotalRebellionPresence => FrenchPresence.TotalPieces + PatriotPresence.TotalPieces;
        public int TotalRoyalistPresence => BritishPresence.TotalPieces + IndianPresence.TotalPieces;

    }
}