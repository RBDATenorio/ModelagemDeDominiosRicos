using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModelagemDeDominiosRicos.Catalogo.Application.Services;
using ModelagemDeDominiosRicos.Catalogo.Domain;
using ModelagemDeDominiosRicos.Catalogo.Domain.Interfaces;
using ModelagemDeDominiosRicos.Core.Bus;
using ModelagemDeDominiosRicos.Data.Repository;

namespace ModelagemDeDominiosRicos.API.DependencyInjection
{
    public static class RegistrarServices
    {
        public static void ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
            
        }
    }
}
