using ModelagemDeDominiosRicos.Vendas.Application.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Vendas.Application.Queries
{
    public interface IPedidoQueries
    {
        Task<CarrinhoDTO> ObterCarrinhoCliente(Guid clienteId);
        Task<IEnumerable<PedidoDTO>> ObterPedidosCliente(Guid clienteId);
    }
}
