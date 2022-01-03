using System;

namespace ModelagemDeDominiosRicos.Core.Messages.CommonMessages.DomainEvents
{
    public class DomainEvents : Event
    {
        public DomainEvents(Guid aggregateId)
        {
            AggregatedId = aggregateId;
        }

    }
}
