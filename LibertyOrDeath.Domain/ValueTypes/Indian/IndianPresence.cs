using System;
namespace LibertyOrDeath.Domain.ValueTypes.Indian
{
    public class IndianPresence : Presence
    {
        public IndianPresence(int undergroundWarParties, int activeWarParties, int villages, int raidMarkers)
        {
            UndergroundWarParties = undergroundWarParties;
            ActiveWarParties = activeWarParties;
            Villages = villages;
            RaidMarkers = raidMarkers;
        }

        public int UndergroundWarParties { get; }
        public int ActiveWarParties { get; }
        public int Villages { get; }
        public int RaidMarkers { get; }

        public int TotalPieces => UndergroundWarParties + ActiveWarParties + Villages;
        public bool Exists => TotalPieces > 0;
    }
}
