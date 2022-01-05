using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Events
{
    public class PedidoRascunhoIniciadoEvent : Event
    {
        public PedidoRascunhoIniciadoEvent(Guid clientId, Guid pedidoId)
        {
            AggregatedId = pedidoId;
            ClientId = clientId;
            PedidoId = pedidoId;
        }

        public Guid ClientId { get; private set; }
        public Guid PedidoId { get; private set; }
    }
}
