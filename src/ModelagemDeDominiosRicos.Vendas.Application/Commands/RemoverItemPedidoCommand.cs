using FluentValidation;
using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Commands
{
    public class RemoverItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Guid PedidoId { get; private set; }

        public RemoverItemPedidoCommand(Guid clienteId, Guid produtoId,
                                            Guid pedidoId)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            PedidoId = pedidoId;
        }

        public override bool EhValido()
        {
            ValidationResult = new RemoverItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoverItemPedidoValidation : AbstractValidator<RemoverItemPedidoCommand>
    {
        public RemoverItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto inválido");

            RuleFor(c => c.PedidoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do pedido inválido");
        }
    }
}
