using System;
using System.Collections.Generic;

namespace ModelagemDeDominiosRicos.Vendas.Application.Queries.DTOs
{
    public class CarrinhoDTO
    {
        public Guid PedidoId { get; set; }
        public Guid ClienteId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDesconto { get; set; }
        public string VoucherCodigo { get; set; }

        public List<CarrinhoItemDTO> Items { get; set; } = new List<CarrinhoItemDTO>();
        public CarrinhoPagamentoDTO Pagamento { get; set; }
    }
}
