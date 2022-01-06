using ModelagemDeDominiosRicos.Core.DomainObjects.DTOs;
using System;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Catalogo.Domain.Interfaces
{
    public interface IEstoqueService
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        Task<bool> DebitarListaProdutosPedido(ListaProdutoPedido lista);
        Task<bool> ReporEstoque(Guid produtoId, int quantidade);
        Task<bool> ReporListaProdutosPedido(ListaProdutoPedido lista);
    }
}
