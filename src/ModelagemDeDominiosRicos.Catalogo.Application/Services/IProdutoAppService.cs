using ModelagemDeDominiosRicos.Catalogo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Catalogo.Application.Services
{
    public interface IProdutoAppService
    {
        Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo);
        Task<ProdutoDTO> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoDTO>> ObterTodos();
        Task<IEnumerable<CategoriaDTO>> ObterCategorias();

        Task AdicionarProduto(ProdutoDTO produtoDTO);
        Task AtualizarProduto(ProdutoDTO produtoDTO);

        Task AdicionarCategoria(CategoriaDTO categoriaDTO);
        Task<ProdutoDTO> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoDTO> ReporEstoque(Guid id, int quantidade);
    }
}
