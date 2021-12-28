using ModelagemDeDominiosRicos.Core.DomainObjects;
using System;

namespace ModelagemDeDominiosRicos.Catalogo.Domain.Events
{
    public class ProdutoAbaixoEstoqueEvents : DomainEvents
    {
        public int QuantidadeRestante { get; private set; }
        public ProdutoAbaixoEstoqueEvents(Guid aggregateId, 
                                            int quantidadeRestante) : base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
