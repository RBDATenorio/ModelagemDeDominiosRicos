using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
