using ModelagemDeDominiosRicos.Catalogo.Domain.Events;
using ModelagemDeDominiosRicos.Catalogo.Domain.Interfaces;
using ModelagemDeDominiosRicos.Core.Communication;
using ModelagemDeDominiosRicos.Core.DomainObjects.DTOs;
using ModelagemDeDominiosRicos.Core.Messages.CommonMessages.Notifications;
using System;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMediatrHandler _mediatrHandler;
        public EstoqueService(IProdutoRepository repository,
                                IMediatrHandler mediatrHandler)
        {
            _repository = repository;
            _mediatrHandler = mediatrHandler;
        }
        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            if (!await DebitarItemEstoque(produtoId, quantidade)) return false;

            return await _repository.UnitOfWork.Commit();
        }

        private async Task<bool> DebitarItemEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _repository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade))
            {
                await _mediatrHandler.PublicarNotificacao(new DomainNotification("Estoque", $"Produto - {produto.Nome} sem estoque"));
                return false;
            }

            produto.DebitarEstoque(quantidade);

            // TODO: 10 pode ser parametrizavel em arquivo de configuração
            if (produto.QuantidadeEmEstoque < 10)
            {
                await _mediatrHandler.PublicarEvento(new ProdutoAbaixoEstoqueEvents(produto.Id, produto.QuantidadeEmEstoque));
            }

            _repository.Atualizar(produto);
            return true;
        }

        public async Task<bool> DebitarListaProdutosPedido(ListaProdutoPedido lista)
        {
            foreach (var item in lista.Itens)
            {
                if (!await DebitarItemEstoque(item.Id, item.Quantidade)) return false;
            }

            return await _repository.UnitOfWork.Commit();
        }
        
        public async Task<bool> ReporListaProdutosPedido(ListaProdutoPedido lista)
        {
            foreach (var item in lista.Itens)
            {
                await ReporItemEstoque(item.Id, item.Quantidade);
            }

            return await _repository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var sucesso = await ReporItemEstoque(produtoId, quantidade);

            if (!sucesso) return false;

            return await _repository.UnitOfWork.Commit();
        }

        private async Task<bool> ReporItemEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _repository.ObterPorId(produtoId);

            if (produto == null) return false;
            produto.ReporEstoque(quantidade);

            _repository.Atualizar(produto);

            return true;
        }
    }
}
