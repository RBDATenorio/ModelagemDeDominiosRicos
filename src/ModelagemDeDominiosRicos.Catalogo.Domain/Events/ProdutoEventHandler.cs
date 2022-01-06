using MediatR;
using ModelagemDeDominiosRicos.Catalogo.Domain.Interfaces;
using ModelagemDeDominiosRicos.Core.Communication;
using ModelagemDeDominiosRicos.Core.Messages.CommonMessages.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvents>,
                                       INotificationHandler<PedidoIniciadoEvent>
    {
        private readonly IProdutoRepository _repository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediatrHandler _mediatrHandler;
        public ProdutoEventHandler(IProdutoRepository repository,
                                   IEstoqueService estoqueService,
                                   IMediatrHandler mediatrHandler)
        {
            _repository = repository;
            _estoqueService = estoqueService;
            _mediatrHandler = mediatrHandler;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvents mensagem, CancellationToken cancellationToken)
        {
            var produto = await _repository.ObterPorId(mensagem.AggregatedId);

            // Aqui poderia ser feito o envio de email, compra de novos produtos...
        }

        public async Task Handle(PedidoIniciadoEvent mensagem, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(mensagem.ProdutosPediso);

            if(result)
            {
                await _mediatrHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(mensagem.PedidoId, mensagem.ClientId,
                                                            mensagem.Total, mensagem.ProdutosPediso, mensagem.NomeCartao,
                                                            mensagem.NumeroCartao, mensagem.ExpiracaoCartao, mensagem.CvvCartao));
            }
            else
            {
                await _mediatrHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(mensagem.PedidoId, mensagem.ClientId));
            }
        }
    }
}
