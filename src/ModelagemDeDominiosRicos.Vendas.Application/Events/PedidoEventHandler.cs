using MediatR;
using ModelagemDeDominiosRicos.Core.Communication;
using ModelagemDeDominiosRicos.Core.Messages.CommonMessages.IntegrationEvents;
using ModelagemDeDominiosRicos.Vendas.Application.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Vendas.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoAtualizadoEvent>,
                                        INotificationHandler<PedidoRascunhoIniciadoEvent>,
                                        INotificationHandler<PedidoRascunhoItemAdicionadoEvent>,
                                        INotificationHandler<PedidoEstoqueRejeitadoEvent>,
                                        INotificationHandler<PagamentoRealizadoEvent>,
                                        INotificationHandler<PagamentoRecusadoEvent>

    {
        private readonly IMediatrHandler _mediatrHandler;

        public PedidoEventHandler(IMediatrHandler mediatrHandler)
        {
            _mediatrHandler = mediatrHandler;
        }

        public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            // Aqui pode ser feito algo como atualizar a base de leitura
            return Task.CompletedTask;
        }

        public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            // Aqui pode ser feito algo como atualizar a base de leitura
            return Task.CompletedTask;
        }

        public Task Handle(PedidoRascunhoItemAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            // Aqui pode ser feito algo como atualizar a base de leitura
            return Task.CompletedTask;
        }

        public async Task Handle(PedidoEstoqueRejeitadoEvent mensagem, CancellationToken cancellationToken)
        {
            await _mediatrHandler.EnviarCommand(new CancelarProcessamentoPedidoCommand(mensagem.PedidoId, mensagem.ClientId));
        }

        public async Task Handle(PagamentoRealizadoEvent mensagem, CancellationToken cancellationToken)
        {
            await _mediatrHandler.EnviarCommand(new FinalizarPedidoCommand(mensagem.PedidoId, mensagem.ClienteId));
        }

        public async Task Handle(PagamentoRecusadoEvent mensagem, CancellationToken cancellationToken)
        {
            await _mediatrHandler.EnviarCommand(new CancelarProcessamentoPedidoEstornarEstoqueCommand(mensagem.PedidoId, mensagem.ClienteId));
        }
    }
}
