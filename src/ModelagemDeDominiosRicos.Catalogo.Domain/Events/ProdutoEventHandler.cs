using MediatR;
using ModelagemDeDominiosRicos.Catalogo.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvents>
    {
        private readonly IProdutoRepository _repository;

        public ProdutoEventHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvents mensagem, CancellationToken cancellationToken)
        {
            var produto = await _repository.ObterPorId(mensagem.AggregatedId);

            // Aqui poderia ser feito o envio de email, compra de novos produtos...
        }
    }
}
