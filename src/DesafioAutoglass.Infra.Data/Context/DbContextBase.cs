
using Microsoft.EntityFrameworkCore;

using DesafioAutoglass.Domain.Entities;
using DesafioAutoglass.Infra.Data.Mappings;

namespace DesafioAutoglass.Infra.Data.Context
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions<DbContextBase> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produto { get; set; } = null!;

    }
}
