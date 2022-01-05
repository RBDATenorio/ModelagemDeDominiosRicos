using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Events
{
    public class PedidoRascunhoItemAdicionadoEvent : Event
    {

        public Guid ClientId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public int Quantidade { get; private set; }
        public PedidoRascunhoItemAdicionadoEvent(Guid clientId, Guid pedidoId,
                                                 Guid produtoId, decimal valor,
                                                 int quantidade)
        {
            AggregatedId = pedidoId;
            ClientId = clientId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            ValorUnitario = valor;
            Quantidade = quantidade;
        }
    }
}
