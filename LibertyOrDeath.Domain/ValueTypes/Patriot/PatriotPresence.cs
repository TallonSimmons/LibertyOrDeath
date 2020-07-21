using System;
namespace LibertyOrDeath.Domain.ValueTypes.Patriot
{
    public class PatriotPresence : Presence
    {
        public PatriotPresence(int undergroundMilitia, int activeMilitia, int continentals, int forts, int propagandaMarkers)
        {
            UnderGroundMilitia = SetPresenceOrDefault(undergroundMilitia);
            Continentals = SetPresenceOrDefault(continentals);
            ActiveMilitia = SetPresenceOrDefault(activeMilitia);
            Forts = SetPresenceOrDefault(forts);
            PropagandaMarkers = propagandaMarkers;
        }

        public int UnderGroundMilitia { get; set; }
        public int Continentals { get; set; }
        public int ActiveMilitia { get; set; }
        public int Forts { get; }
        public int PropagandaMarkers { get; }
        public bool Fortified => Forts > 0;
        public bool Unfortified => Forts == 0;
        public int TotalPieces => UnderGroundMilitia + Continentals + ActiveMilitia + Forts;
        public bool Exists => TotalPieces > 0;
        public bool HasUndergroundMilita => UnderGroundMilitia > 0;

        public bool TryActivateMilitia()
        {
            if(UnderGroundMilitia == 0)
            {
                return false;
            }

            UnderGroundMilitia--;
            ActiveMilitia++;
            return true;
        }
    }
}
