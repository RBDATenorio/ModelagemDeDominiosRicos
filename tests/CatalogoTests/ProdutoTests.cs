using ModelagemDeDominiosRicos.Catalogo.Domain;
using ModelagemDeDominiosRicos.Catalogo.Domain.ValueObjects;
using ModelagemDeDominiosRicos.Core.DomainObjects;
using System;
using Xunit;

namespace CatalogoTests
{
    public class ProdutoTests
    {
        [Theory]
        [InlineData("", "Descrição", false, 100, "CaminhoDaImagem", 1, 1, 3, "Nome é obrigatório.")]
        [InlineData("", "", false, 150, "CaminhoDaImagem", 1, 1, 3, "Nome é obrigatório.")]
        public void Produto_Validar_ValidacoesDevemRetornarExecptions(string nome, string descricao,
                                                                        bool ativo, decimal valor,
                                                                        string imagem, decimal altura, 
                                                                        decimal largura, decimal profundidade,
                                                                        string mensagem)
        {
            // Arrange, Act, Assert

            var ex = Assert.Throws<DomainException>(() =>
                new Produto(Guid.NewGuid(), nome, descricao, ativo, valor, DateTime.Now, imagem, 
                            new Dimensoes(altura, largura, profundidade))
            );

            Assert.Equal(mensagem, ex.Message);
        }
    }
}
