using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service.Service;
using System.Text.Json.Serialization;

namespace Aplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "All",
                                  builder =>
                                  {
                                      builder.WithOrigins("*");
                                  });
            });

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "be3 Test - Leandro Romanelli",
                        Version = "v1",
                        Description = "be3 Test - Leandro Romanelli",
                        Contact = new OpenApiContact
                        {
                            Name = "Leandro Romanelli",
                            Url = new Uri("https://github.com/leandroromanelli")
                        }
                    });
            });


            services.AddScoped<IPrioridadeRepository, PrioridadeRepository>();
            services.AddScoped<IPrioridadeService, PrioridadeService>();

            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusService, StatusService>();

            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<ITarefaService, TarefaService>();


            services.AddDbContext<TarefaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("All");

            app.UseSwagger();
            
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "be3 Test - Leandro Romanelli");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
