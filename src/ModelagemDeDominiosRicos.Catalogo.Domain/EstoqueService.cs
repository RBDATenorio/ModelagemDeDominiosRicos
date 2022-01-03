using ModelagemDeDominiosRicos.Catalogo.Domain.Events;
using ModelagemDeDominiosRicos.Catalogo.Domain.Interfaces;
using ModelagemDeDominiosRicos.Core.Communication;
using System;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMediatrHandler _bus;
        public EstoqueService(IProdutoRepository repository,
                                IMediatrHandler bus)
        {
            _repository = repository;
            _bus = bus;
        }
        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _repository.ObterPorId(produtoId);

            if (produto is null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            // Exemplo de utilizacao de eventos de dominio
            if(produto.QuantidadeEmEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvents(produto.Id, produto.QuantidadeEmEstoque));
            }

            produto.DebitarEstoque(quantidade);
            
            _repository.Atualizar(produto);

            return await _repository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _repository.ObterPorId(produtoId);

            if (produto is null) return false;

            produto.ReporEstoque(quantidade);

            _repository.Atualizar(produto);

            return await _repository.UnitOfWork.Commit();
        }
    }
}
