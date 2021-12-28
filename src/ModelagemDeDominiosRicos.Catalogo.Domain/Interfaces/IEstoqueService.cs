using System;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Catalogo.Domain.Interfaces
{
    public interface IEstoqueService
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        Task<bool> ReporEstoque(Guid produtoId, int quantidade);
    }
}
