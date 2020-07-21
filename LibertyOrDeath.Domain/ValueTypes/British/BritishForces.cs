namespace LibertyOrDeath.Domain.ValueTypes.British
{
    public class BritishForces : Forces
    {
        public int AvailableRegulars { get; }
        public int AvailableTories { get; }
        public int AvailableForts { get; }
        public int UnavailableRegulars { get; }
        public int UnavailableTories { get; }
        public int NumberOfRegularsDeployed => 25 - AvailableRegulars - UnavailableRegulars;

        public BritishForces(int availableRegulars, int availableTories, int availableForts, int unavailableRegulars, int unavailableTories)
            : base(availableRegulars + availableTories, unavailableRegulars + unavailableTories)
        {
            AvailableRegulars = availableRegulars;
            AvailableTories = availableTories;
            AvailableForts = availableForts;
            UnavailableRegulars = unavailableRegulars;
            UnavailableTories = unavailableTories;
        }
    }
}
