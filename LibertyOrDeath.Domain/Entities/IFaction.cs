using System;
using System.Collections.Generic;

namespace LibertyOrDeath.Domain.Entities
{
    public interface IFaction
    {
        int Id { get; }
        string Title { get; }
        int Resources { get; }
        Dictionary<int, string> EventInstruction { get; }
    }
}
