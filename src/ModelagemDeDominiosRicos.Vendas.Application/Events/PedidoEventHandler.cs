using MediatR;
using ModelagemDeDominiosRicos.Core.Messages.CommonMessages.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Vendas.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoAtualizadoEvent>,
                                        INotificationHandler<PedidoRascunhoIniciadoEvent>,
                                        INotificationHandler<PedidoRascunhoItemAdicionadoEvent>,
                                        INotificationHandler<PedidoEstoqueRejeitadoEvent>

    {
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

        public Task Handle(PedidoEstoqueRejeitadoEvent mensagem, CancellationToken cancellationToken)
        {
            // cancelar o processamento do pedido - retornando erro para o cliente
            return Task.CompletedTask;
        }
    }
}
