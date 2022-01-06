using ModelagemDeDominiosRicos.Core.DomainObjects.DTOs;
using System;

namespace ModelagemDeDominiosRicos.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoEstoqueConfirmadoEvent : IntegrationEvent
    {

        public Guid PedidoId { get; private set; }
        public Guid ClientId { get; private set; }
        public decimal Total { get; private set; }
        public ListaProdutoPedido ProdutosPedido { get; private set; }
        public string NomeCartao { get; private set; }
        public string NumeroCartao { get; private set; }
        public string ExpiracaoCartao { get; private set; }
        public string CvvCartao { get; private set; }

        public PedidoEstoqueConfirmadoEvent(Guid pedidoId, Guid clientId, decimal total, 
                                            ListaProdutoPedido produtosPedido, string nomeCartao,
                                            string numeroCartao, string expiracaoCartao, string cvvCartao)
        {
            AggregatedId = pedidoId;
            PedidoId = pedidoId;
            ClientId = clientId;
            Total = total;
            ProdutosPedido = produtosPedido;
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            ExpiracaoCartao = expiracaoCartao;
            CvvCartao = cvvCartao;
        }

    }
}
