using ModelagemDeDominiosRicos.Core.DomainObjects;

namespace ModelagemDeDominiosRicos.Catalogo.Domain
{
    public class Categoria : Entity
    {

        public string Nome { get; private set; }
        public int Codigo { get; private set; }
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public override void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode ser vazio.");
        }
    }
}
