using ModelagemDeDominiosRicos.Core.DomainObjects.DTOs;
using System;

namespace ModelagemDeDominiosRicos.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoProcessamentoCanceladoEvent : Event
    {

        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public ListaProdutoPedido ProdutosPedido { get; private set; }

        public PedidoProcessamentoCanceladoEvent(Guid pedidoId, Guid clienteId, ListaProdutoPedido produtosPedido)
        {
            AggregatedId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
            ProdutosPedido = produtosPedido;
        }
    }
}
