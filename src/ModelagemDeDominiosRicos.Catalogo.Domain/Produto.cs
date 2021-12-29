using ModelagemDeDominiosRicos.Catalogo.Domain.ValueObjects;
using ModelagemDeDominiosRicos.Core.DomainObjects;
using System;

namespace ModelagemDeDominiosRicos.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
        public Categoria Categoria { get; private set; }
        
        protected Produto() { }
        public Produto(Guid categoriaId, string nome, string descricao, 
                        bool ativo, decimal valor, DateTime dataCadastro, 
                        string imagem, Dimensoes dimensoes)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            Dimensoes = dimensoes;

            Validar();
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente.");
            QuantidadeEmEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEmEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEmEstoque >= quantidade;
        }

        public override void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "Nome é obrigatório.");
            Validacoes.ValidarSeVazio(Descricao, "Descrição é obrigátória.");
            Validacoes.ValidarSeMenorIgualAMinimo(Valor, 0, "O campo valor do produto não pode ser menor que 0.");
        }
    }
}
