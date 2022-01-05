using ModelagemDeDominiosRicos.Core.Communication;
using ModelagemDeDominiosRicos.Core.DomainObjects;
using System.Linq;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Vendas.Data
{
    public static class MediatrExtensions
    {
        public static async Task PublicarEventos(this IMediatrHandler mediatr, VendasContext context)
        {
            var domainEntities = context.ChangeTracker
                                        .Entries<Entity>()
                                        .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediatr.PublicarEvento(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
