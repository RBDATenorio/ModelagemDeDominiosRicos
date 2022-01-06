using System;

namespace ModelagemDeDominiosRicos.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoEstoqueRejeitadoEvent : IntegrationEvent
    {

        public Guid PedidoId { get; private set; }
        public Guid ClientId { get; private set; }

        public PedidoEstoqueRejeitadoEvent(Guid pedidoId, Guid clientId)
        {
            AggregatedId = pedidoId;
            PedidoId = pedidoId;
            ClientId = clientId;
        }

    }
}
