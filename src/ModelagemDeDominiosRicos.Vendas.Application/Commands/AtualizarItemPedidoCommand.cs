using FluentValidation;
using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Commands
{
    public class AtualizarItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Guid PedidoId { get; private set; }
        public int Quantidade { get; private set; }

        public AtualizarItemPedidoCommand(Guid clienteId, Guid produtoId, Guid pedidoId,
                                            int quantidade)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            Quantidade = quantidade;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarItemPedidoValidation : AbstractValidator<AtualizarItemPedidoCommand>
    {
        public AtualizarItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto inválido");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade miníma de um item é 1");
        }
    }
}
