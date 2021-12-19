namespace ModelagemDeDominiosRicos.Core.DomainObjects
{
    public class Validacoes
    {
        public static void ValidarCaracteres(string valor, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length > maximo) throw new DomainException(mensagem);
        }
        public static void ValidarCaracteres(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length > maximo || length < minimo) throw new DomainException(mensagem);
        }
        public static void ValidarSeNulo(object object1, string mensagem)
        {
            if (object1 is null) throw new DomainException(mensagem);
        }
        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (string.IsNullOrEmpty(valor)) throw new DomainException(mensagem);
        }
        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo) throw new DomainException(mensagem);
        }
        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo) throw new DomainException(mensagem);
        }
        public static void ValidarSeMenorIgualAMinimo(decimal valor, decimal minimo, string mensagem)
        {
            if (valor < minimo) throw new DomainException(mensagem);
        }
    }
}
