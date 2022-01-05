using System;
using System.Collections.Generic;

namespace ModelagemDeDominiosRicos.Core.DomainObjects.DTOs
{
    public class ListaProdutoPedido
    {
        public Guid PedidoId { get; set; }
        public ICollection<Item> Itens { get; set; }
    }

    public class Item
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
    }
}
