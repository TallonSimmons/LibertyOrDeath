using System;
namespace LibertyOrDeath.Domain.ValueTypes
{
    public abstract class Forces
    {
        protected Forces(int available, int unavailable)
        {
            Available = available;
            Unavailable = unavailable;
        }

        public int Available { get; }
        public bool AnyAvailable => Available > 0;
        public int Unavailable { get; }
        public bool AnyUnavailable => Unavailable > 0;
    }
}
