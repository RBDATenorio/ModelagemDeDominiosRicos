using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Commands
{
    public class CancelarProcessamentoPedidoCommand : Command
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }

        public CancelarProcessamentoPedidoCommand(Guid pedidoId, Guid clienteId)
        {
            AggregatedId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }
    }
}
