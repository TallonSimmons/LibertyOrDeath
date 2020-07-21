using System;
using System.Collections.Generic;
using LibertyOrDeath.Domain.ValueTypes;
using LibertyOrDeath.Domain.ValueTypes.Patriot;

namespace LibertyOrDeath.Domain.Entities
{
    public class Patriot : Faction
    {
        public Patriot(int id, string title, int resources)
            : base(id, title, resources)
        {
        }

        public PatriotForces Forces { get; }
    }
}
