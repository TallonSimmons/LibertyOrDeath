using System;
using System.Collections.Generic;

namespace LibertyOrDeath.Domain.Entities
{
    public class French :  Faction
    {
        public French(int id, string title, int resources)
            :base (id, title, resources)
        {
        }
    }
}
