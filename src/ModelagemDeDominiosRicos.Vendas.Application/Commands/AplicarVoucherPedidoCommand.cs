using FluentValidation;
using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Commands
{
    public class AplicarVoucherPedidoCommand : Command
    {

        public Guid ClienteId { get; private set; }
        public string CodigoVoucher { get; private set; }

        public AplicarVoucherPedidoCommand(Guid clienteId, string codigoVoucher)
        {
            ClienteId = clienteId;
            CodigoVoucher = codigoVoucher;
        }

        public override bool EhValido()
        {
            ValidationResult = new AplicarVoucherPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }

    public class AplicarVoucherPedidoValidation : AbstractValidator<AplicarVoucherPedidoCommand>
    {
        public AplicarVoucherPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.CodigoVoucher)
                .NotEmpty()
                .WithMessage("Voucher inválido");
        }
    }
}
