using FluentValidation;
using ModelagemDeDominiosRicos.Core.Messages;
using System;

namespace ModelagemDeDominiosRicos.Vendas.Application.Commands
{
    public class AdicionarItemPedidoCommand : Command
    {
        public AdicionarItemPedidoCommand(Guid clientId, Guid produtoId, 
                                            string nome, int quantidade,
                                            decimal valorUnitario)
        {
            ClientId = clientId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarItemPedidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public Guid ClientId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
    }

    public class AdicionarItemPedidoCommandValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoCommandValidation()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente é obrigatório.");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto é obrigatório.");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O Nome do produto é obrigatório.");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("Quantidade deve ser no mínimo 1.");

            RuleFor(c => c.ValorUnitario)
                .GreaterThan(0)
                .WithMessage("Valor unitário deve ser no mínimo 1.");
        }
    }
}
