using ModelagemDeDominiosRicos.Core.DomainObjects;
using System;

namespace ModelagemDeDominiosRicos.Pagamentos.Business
{
    public class Transacao : Entity
    {
        public Guid PedidoId { get; set; }
        public Guid PagamentoId { get; set; }
        public decimal Total { get; set; }
        public StatusTransacao StatusTransacao { get; set; }

        // EF. Rel.
        public Pagamento Pagamento { get; set; }
        public override void Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
