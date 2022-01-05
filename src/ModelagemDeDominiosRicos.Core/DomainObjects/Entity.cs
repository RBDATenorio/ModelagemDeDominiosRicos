using ModelagemDeDominiosRicos.Core.Messages;
using System;
using System.Collections.Generic;

namespace ModelagemDeDominiosRicos.Core.DomainObjects
{
    public abstract class Entity
    {

        public Guid Id { get; set; }

        private List<Event> _notificacoes;
        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

        public void AdicionarEvento(Event evento)
        {
            _notificacoes = _notificacoes ?? new List<Event>();
            _notificacoes.Add(evento);
        }

        public void RemoverEvento(Event evento)
        {
            _notificacoes?.Remove(evento);
        }

        public void LimparEventos()
        {
            _notificacoes?.Clear();
        }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Validar();
    }
}
