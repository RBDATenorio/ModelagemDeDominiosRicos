using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Core.DomainObjects
{
    public class DomainEvents : Event
    {
        public DomainEvents(Guid aggregateId)
        {
            AggregatedId = aggregateId;
        }

    }
}
