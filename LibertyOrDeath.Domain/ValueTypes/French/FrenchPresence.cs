namespace LibertyOrDeath.Domain.ValueTypes.French
{
    public class FrenchPresence : Presence
    {
        public FrenchPresence(int blockades, int regulars)
        {
            Blockades = SetPresenceOrDefault(blockades);
            Regulars = SetPresenceOrDefault(regulars);
        }

        public int Blockades { get; }
        public int Regulars { get; }
        public int TotalPieces => Blockades + Regulars;
        public bool BlockadePresent => Blockades > 0;
        public bool Exists => TotalPieces > 0;
    }
}
