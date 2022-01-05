using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModelagemDeDominiosRicos.Catalogo.Application.Services;
using ModelagemDeDominiosRicos.Catalogo.Domain;
using ModelagemDeDominiosRicos.Catalogo.Domain.Events;
using ModelagemDeDominiosRicos.Catalogo.Domain.Interfaces;
using ModelagemDeDominiosRicos.Core.Communication;
using ModelagemDeDominiosRicos.Core.Messages.CommonMessages.Notifications;
using ModelagemDeDominiosRicos.Data.Repository;
using ModelagemDeDominiosRicos.Vendas.Application.Commands;
using ModelagemDeDominiosRicos.Vendas.Application.Events;
using ModelagemDeDominiosRicos.Vendas.Application.Queries;
using ModelagemDeDominiosRicos.Vendas.Data.Repository;
using ModelagemDeDominiosRicos.Vendas.Domain;

namespace ModelagemDeDominiosRicos.WebAPI.DependencyInjection
{
    public static class RegistrarServices
    {
        public static void ResolverDependencias(this IServiceCollection services)
        {
            
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IMediatrHandler, MediatrHandler>();
            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvents>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();

            // Vendas
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, PedidoCommandHandler>();

            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<INotificationHandler<PedidoAtualizadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoRascunhoItemAdicionadoEvent>, PedidoEventHandler>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();
        }
    }
}
