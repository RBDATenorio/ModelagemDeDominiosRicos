using ModelagemDeDominiosRicos.Core.Messages;
using ModelagemDeDominiosRicos.Core.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Core.Communication
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarCommand<T>(T command) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
    }
}
