namespace ModelagemDeDominiosRicos.Vendas.Application.Queries.DTOs
{
    public class CarrinhoPagamentoDTO
    {
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }
    }
}
