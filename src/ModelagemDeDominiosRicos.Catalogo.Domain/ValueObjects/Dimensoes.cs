using ModelagemDeDominiosRicos.Core.DomainObjects;

namespace ModelagemDeDominiosRicos.Catalogo.Domain.ValueObjects
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorIgualAMinimo(altura, 1, "O campo altura não pode ser menor que 1.");
            Validacoes.ValidarSeMenorIgualAMinimo(largura, 1, "O campo largura não pode ser menor que 1.");
            Validacoes.ValidarSeMenorIgualAMinimo(profundidade, 1, "O campo profundidade não pode ser menor que 1.");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }
    }
}
