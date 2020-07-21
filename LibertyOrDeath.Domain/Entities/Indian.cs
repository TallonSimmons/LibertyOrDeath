using System;
using System.Collections.Generic;

namespace LibertyOrDeath.Domain.Entities
{
    public class Indian :  Faction
    {
        public Indian(int id, string title, int resources)
            : base(id, title, resources)
        {
        }
    }
}
