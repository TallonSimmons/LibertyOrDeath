using System;
using System.Collections.Generic;
using LibertyOrDeath.Domain.ValueTypes.British;

namespace LibertyOrDeath.Domain.Entities
{
    public class British :  Faction
    {
        public British(int id, string title, int resources, BritishForces forces)
            : base(id, title, resources)
        {
            Forces = forces;
        }

        public BritishForces Forces { get; }
    }
}
