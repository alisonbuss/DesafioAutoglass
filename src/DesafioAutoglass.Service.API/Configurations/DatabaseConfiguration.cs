
using Microsoft.EntityFrameworkCore;

using DesafioAutoglass.Infra.Data.Context;

namespace DesafioAutoglass.Service.API.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            // services.AddDbContext<DbContextBase>(options =>
            //         options.UseInMemoryDatabase(databaseName: "InMemoryDataSource"));

            // services.AddDbContext<DbContextBase>(options =>
            //         options.UseSqlite(configuration.GetConnectionString("SqliteConnection")));

            services.AddDbContext<DbContextBase>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            services.AddScoped<DbContextBase, DbContextBase>();
        }

        public static void UseDatabaseConfiguration(this WebApplication app, IWebHostEnvironment environment)
        {
            using(var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DbContextBase>();

                if (environment.IsDevelopment())
                {
                    // Drop the database if it exists.
                    // dbContext.Database.EnsureDeleted();

                    // Create the database if it doesn't exist.
                    // dbContext.Database.EnsureCreated();

                    // // Add 7 initial users to the system for testing:
                    // foreach (var produto in "PROD012DC,PROD014DC,PROD055DC,PROD077DC".Split(','))
                    // {
                    //     var currentDate = new DateTime();
                    //     var newProduto = new Produto(
                    //         $"{produto}",
                    //         $"Produto {produto}",
                    //         true,
                    //         currentDate,
                    //         currentDate.AddDays(33),
                    //         "",
                    //         "",
                    //         ""
                    //     );
                    //     dbContext.Set<Produto>().Add(newProduto);
                    // }
                    // dbContext.SaveChanges();
                }
            }
        }

    }
}
