using System;
namespace LibertyOrDeath.Domain.ValueTypes
{
    public abstract class Presence
    {
        // TODO: Move to an extension method and get rid of this type.
        protected int SetPresenceOrDefault(int presenceNumber)
            => presenceNumber >= 0 ? presenceNumber : 0;
    }
}
