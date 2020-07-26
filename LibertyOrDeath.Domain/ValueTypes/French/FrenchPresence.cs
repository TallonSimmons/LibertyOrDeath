namespace LibertyOrDeath.Domain.ValueTypes.French
{
    public class FrenchPresence : Presence
    {
        public FrenchPresence(int blockades, int regulars, int squadrons = 0)
        {
            Blockades = SetPresenceOrDefault(blockades);
            Regulars = SetPresenceOrDefault(regulars);
            Squadrons = SetPresenceOrDefault(squadrons);
        }

        public int Blockades { get; }
        public int Regulars { get; }
        public int Squadrons { get; }
        public int TotalPieces => Blockades + Regulars;
        public bool BlockadePresent => Blockades > 0;
        public bool Exists => TotalPieces > 0;
    }
}
