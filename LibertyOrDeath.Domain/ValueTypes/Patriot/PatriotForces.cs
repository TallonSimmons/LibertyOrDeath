using System;
namespace LibertyOrDeath.Domain.ValueTypes.Patriot
{
    public class PatriotForces : Forces
    {
        public PatriotForces(int availableMiltia, int availableContinentals, int availableForts)
            : base (availableMiltia + availableContinentals, 0)
        {
            AvailableMiltia = availableMiltia;
            AvailableContinentals = availableContinentals;
            AvailableForts = availableForts;
        }

        public int AvailableMiltia { get; }
        public int AvailableContinentals { get; }
        public int AvailableForts { get; }
    }
}
