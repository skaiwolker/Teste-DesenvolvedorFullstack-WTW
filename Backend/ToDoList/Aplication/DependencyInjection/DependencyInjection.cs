using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Infrastructure.Repository;
using Service.Services.Base;
using Services.Service;

namespace Aplication.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPrioridadeRepository, PrioridadeRepository>();
            services.AddScoped<IPrioridadeService, PrioridadeService>();

            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusService, StatusService>();

            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<ITarefaService, TarefaService>();

            return services;
        }
    }
}
