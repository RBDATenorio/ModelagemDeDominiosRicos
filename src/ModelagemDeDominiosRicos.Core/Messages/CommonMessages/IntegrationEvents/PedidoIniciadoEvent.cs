using ModelagemDeDominiosRicos.Core.DomainObjects.DTOs;
using System;

namespace ModelagemDeDominiosRicos.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoIniciadoEvent : IntegrationEvent
    {
        public PedidoIniciadoEvent(Guid pedidoId, Guid clientId, decimal total, ListaProdutoPedido produtosPediso, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
        {
            PedidoId = pedidoId;
            ClientId = clientId;
            Total = total;
            ProdutosPediso = produtosPediso;
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            ExpiracaoCartao = expiracaoCartao;
            CvvCartao = cvvCartao;
        }

        public Guid PedidoId { get; private set; }
        public Guid ClientId { get; private set; }
        public decimal Total { get; private set; }
        public ListaProdutoPedido ProdutosPediso { get; private set; }
        public string NomeCartao { get; private set; }
        public string NumeroCartao { get; private set; }
        public string ExpiracaoCartao { get; private set; }
        public string CvvCartao { get; private set; }

    }
}
