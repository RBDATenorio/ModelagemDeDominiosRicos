using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Events
{
    public class PedidoProdutoRemovidoEvent : Event
    {

        public Guid ClientId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }

        public PedidoProdutoRemovidoEvent(Guid clientId, Guid pedidoId, Guid produtoId)
        {
            AggregatedId = pedidoId;
            ClientId = clientId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
        }

    }
}
