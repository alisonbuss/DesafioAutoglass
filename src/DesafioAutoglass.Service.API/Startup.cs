
using Microsoft.Extensions.FileProviders;

using DesafioAutoglass.Service.API.Configurations;

namespace DesafioAutoglass.Service.WebAPI
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
            // Add services to the container:

            // Setting DBContexts:
            services.AddDatabaseConfiguration(Configuration);

            // Dependency Injection Configuration:
            services.AddDependencyInjectionConfiguration();

            services.AddSwaggerGen();
            services.AddControllers();
            services.AddDirectoryBrowser();
            services.AddEndpointsApiExplorer();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "DefaultPolicy", policy =>
                {
                    policy.WithOrigins("http://*", "https://*")
                          .WithMethods("OPTIONS", "GET", "POST", "PUT", "DELETE", "PATCH")
                          .WithExposedHeaders("x-perpro", "Cache-control", "Pragma", "x-hubin-info")
                          .AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            // Serve static files
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(
                    environment.ContentRootPath, "StaticContents/public")
                ),
                EnableDirectoryBrowsing = true,
                RequestPath = "/web",
            });

            // Use initial database configurations.
            app.UseDatabaseConfiguration(environment);

            app.UseCors();

            app.UseRouting();

            app.MapGet("/", () => "Hello World!");

            app.MapControllers();
        }
    }
}
