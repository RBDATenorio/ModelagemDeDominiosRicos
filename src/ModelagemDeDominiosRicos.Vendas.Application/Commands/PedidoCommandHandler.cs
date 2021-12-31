using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Vendas.Application.Commands
{
    public class PedidoCommandHandler : IRequestHandler<AdicionarItemPedidoCommand, bool>
    {
        public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(message)) return false;
            
            return false;
        }

        public bool ValidarCommand(AdicionarItemPedidoCommand message)
        {
            if (message.EhValido()) return true;

            foreach(var erro in message.ValidationResult.Errors)
            {
                // lancar evento de erro aqui
            }

            return false;
        }
    }
}
