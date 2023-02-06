
using Microsoft.Extensions.DependencyInjection;

// using AutoMapper;

using DesafioAutoglass.Common.Interfaces;
using DesafioAutoglass.Common.Impls;

using DesafioAutoglass.Domain.Interfaces.Services;
using DesafioAutoglass.Domain.Services;

using DesafioAutoglass.Domain.Interfaces.Repositories;
using DesafioAutoglass.Infra.Data.Repositories;

using DesafioAutoglass.Application.Interfaces;
using DesafioAutoglass.Application.Services;
using DesafioAutoglass.Application.Mappers;

namespace DesafioAutoglass.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapperAPI
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Common
            services.AddSingleton(typeof(ILoggerManager<>), typeof(LoggerManager<>));

            // Domain
            services.AddScoped<IServiceProduto, ServiceProduto>();

            // Infra - Data
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IRepositoryProduto, RepositoryProduto>();

            // Application - AutoMapper
            services.AddAutoMapper(typeof(EntityToDtoMappingProduto), typeof(DtoToEntityMappingProduto));
            services.AddAutoMapper(typeof(EntityToDtoMappingProduto), typeof(DtoToEntityMappingProduto));

            // Application - AppService
            services.AddScoped<IAppServiceProduto, AppServiceProduto>();

        }
    }
}
