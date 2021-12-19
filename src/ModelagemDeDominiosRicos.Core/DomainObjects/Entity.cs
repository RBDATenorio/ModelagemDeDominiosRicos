using System;

namespace ModelagemDeDominiosRicos.Core.DomainObjects
{
    public abstract class Entity
    {

        public Guid Id { get; set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Validar();
    }
}
