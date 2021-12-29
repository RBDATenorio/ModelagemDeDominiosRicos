using ModelagemDeDominiosRicos.Core.DomainObjects;
using System;

namespace ModelagemDeDominiosRicos.Core.Data
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
