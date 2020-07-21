using System;
namespace LibertyOrDeath.Domain.ValueTypes.British
{
    public class BritishPresence : Presence
    {
        private int regulars;
        private int tories;
        private int forts;

        public BritishPresence(int regulars, int tories, int forts)
        {
            Regulars = SetPresenceOrDefault(regulars);
            Tories = SetPresenceOrDefault(tories);
            Forts = SetPresenceOrDefault(forts);
        }

        public int Regulars { get => regulars; set => regulars = SetPresenceOrDefault(value); }
        public int Tories { get => tories; set => tories = SetPresenceOrDefault(value); }
        public int Forts { get => forts; set => forts = SetPresenceOrDefault(value); }
        public int TotalPieces => Regulars + Tories + Forts;
        public bool Exists => TotalPieces > 0;
        public bool HasRegulars => Regulars > 0;
        public bool HasTories => Tories > 0;
    }
}
