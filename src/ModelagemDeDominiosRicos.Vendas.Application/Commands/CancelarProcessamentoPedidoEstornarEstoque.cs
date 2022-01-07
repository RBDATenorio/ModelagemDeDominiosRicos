using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Commands
{
    public class CancelarProcessamentoPedidoEstornarEstoqueCommand : Command
    {
        public CancelarProcessamentoPedidoEstornarEstoqueCommand(Guid pedidoId, Guid clienteId)
        {
            AggregatedId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }

        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
    }
}
