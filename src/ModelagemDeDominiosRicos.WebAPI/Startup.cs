using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ModelagemDeDominiosRicos.WebAPI.DependencyInjection;
using ModelagemDeDominiosRicos.Catalogo.Data;
using ModelagemDeDominiosRicos.Vendas.Data;
using ModelagemDeDominiosRicos.Pagamentos.Data;
using System.Collections.Generic;

namespace ModelagemDeDominiosRicos.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ModelagemDeDominiosRicos.API", Version = "v1" });
                c.SwaggerGeneratorOptions.Servers = new List<OpenApiServer> {
                    new() {Url = "http://testeurl1.com"},
                    new() {Url = "http://testeurl2.com"} };
            });

            services.AddDbContext<CatalogoContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddDbContext<VendasContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddDbContext<PagamentoContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.ResolverDependencias();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModelagemDeDominiosRicos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
