using System;
using System.Collections.Generic;
using LibertyOrDeath.Domain.ValueTypes;

namespace LibertyOrDeath.Domain.Entities
{
    public abstract class Faction
    {
        protected Faction(int id, string title, int resources)
        {
            Id = id;
            Title = title;
            Resources = resources;
        }

        public int Id { get; }
        public string Title { get; }
        public int Resources { get; }
    }
}
