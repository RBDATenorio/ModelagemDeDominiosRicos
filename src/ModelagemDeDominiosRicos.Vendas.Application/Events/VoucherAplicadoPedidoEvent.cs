using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Events
{
    public class VoucherAplicadoPedidoEvent : Event
    {
        public Guid ClientId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid VoucherId { get; private set; }
        
        public VoucherAplicadoPedidoEvent(Guid clientId, Guid pedidoId, Guid voucherId)
        {
            ClientId = clientId;
            PedidoId = pedidoId;
            VoucherId = voucherId;
        }
    }
}
