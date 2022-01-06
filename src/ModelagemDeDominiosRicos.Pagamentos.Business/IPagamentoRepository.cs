using ModelagemDeDominiosRicos.Core.Data;

namespace ModelagemDeDominiosRicos.Pagamentos.Business
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        void Adicionar(Pagamento pagamento);
        void AdicionarTransacao(Transacao transacao);
    }
}
