using Microsoft.EntityFrameworkCore;
using ModelagemDeDominiosRicos.Catalogo.Domain;
using ModelagemDeDominiosRicos.Core.Data;
using ModelagemDeDominiosRicos.Core.Messages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ModelagemDeDominiosRicos.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
            modelBuilder.Ignore<Event>();
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            }
            
            return await base.SaveChangesAsync() > 0;
        }
    }
}

