using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModelagemDeDominiosRicos.Catalogo.Application.Services;
using ModelagemDeDominiosRicos.Catalogo.Domain;
using ModelagemDeDominiosRicos.Catalogo.Domain.Events;
using ModelagemDeDominiosRicos.Catalogo.Domain.Interfaces;
using ModelagemDeDominiosRicos.Core.Bus;
using ModelagemDeDominiosRicos.Data.Repository;
using ModelagemDeDominiosRicos.Vendas.Application.Commands;

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
            
            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();

            // Vendas
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            
        }
    }
}
