using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Infrastructure.Repository;
using Service.Services.Base;

namespace Aplication.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<ITarefaService, TarefaService>();

            return services;
        }
    }
}
