
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using DesafioAutoglass.Domain.Entities;
using DesafioAutoglass.Infra.Data.Mappings;

namespace DesafioAutoglass.Infra.Data.Context
{
    public class DbContextMigration : DbContext
    {
        public DbContextMigration(DbContextOptions<DbContextMigration> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produto { get; set; } = null!;

    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DbContextMigration>
    {
        public DbContextMigration CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Migration.json", false, true)
                .Build();
            var connectionString = configuration.GetConnectionString("SqlServerConnection");

            // Database Connection:
            var builder = new DbContextOptionsBuilder<DbContextMigration>();
            // builder.UseInMemoryDatabase(databaseName: "InMemoryDataSource");
            // Or:
            // builder.UseSqlite(connectionString);
            // Or:
            builder.UseSqlServer(connectionString);

            return new DbContextMigration(builder.Options);
        }
    }
}
