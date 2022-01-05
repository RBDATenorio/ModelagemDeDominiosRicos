using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Events
{
    public class PedidoAtualizadoEvent : Event
    {

        public Guid ClientId { get; private set; }
        public Guid PedidoId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public PedidoAtualizadoEvent(Guid clientId, Guid pedidoId, decimal valorTotal)
        {
            AggregatedId = pedidoId;
            ClientId = clientId;
            PedidoId = pedidoId;
            ValorTotal = valorTotal;
        }
    }
}
