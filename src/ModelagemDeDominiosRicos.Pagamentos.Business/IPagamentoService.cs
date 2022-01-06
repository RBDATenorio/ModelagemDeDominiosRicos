using ModelagemDeDominiosRicos.Core.DomainObjects.DTOs;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Pagamentos.Business
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}
