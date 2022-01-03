using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModelagemDeDominiosRicos.Core.Communication;
using ModelagemDeDominiosRicos.Core.Messages.CommonMessages.Notifications;
using System;

namespace ModelagemDeDominiosRicos.WebAPI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly DomainNotificationHandler _notifications;
        private readonly IMediatrHandler _mediatrHandler;
        // Atributo usado para simular o ID que viria pela claim do JWT
        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected BaseController(INotificationHandler<DomainNotification> notifications, 
                                 IMediatrHandler mediatrHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatrHandler = mediatrHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatrHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }
    }
}
