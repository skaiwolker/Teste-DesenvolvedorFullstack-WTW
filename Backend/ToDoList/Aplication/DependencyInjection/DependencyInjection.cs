using Domain.Entities.Base;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Base;
using Domain.Interfaces.Service;
using Domain.Interfaces.Service.Base;
using Infrastructure.Repository;
using Infrastructure.Repository.Base;
using Service.Service;
using Service.Service.Base;

namespace Aplication.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBaseRepository<EntityBase>, BaseRepository<EntityBase>>();
            services.AddScoped<IBaseService<EntityBase>, BaseService<EntityBase>>();

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
