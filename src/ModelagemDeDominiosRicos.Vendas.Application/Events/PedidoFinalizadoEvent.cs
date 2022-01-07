using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Events
{
    public class PedidoFinalizadoEvent : Event
    {
        public PedidoFinalizadoEvent(Guid pedidoId)
        {
            AggregatedId = pedidoId;
            PedidoId = pedidoId;
        }

        public Guid PedidoId { get; private set; }
    }
}
