using ModelagemDeDominiosRicos.Core.Messages;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Core.Bus
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarCommand<T>(T command) where T : Command;
    }
}
