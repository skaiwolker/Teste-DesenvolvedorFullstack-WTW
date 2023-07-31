using Aplication.DependencyInjection;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
                options.AddPolicy(name: "MyPolicy",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyMethod()
                                             .AllowAnyHeader();
                                  });
            });

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Teste Desenvolvedor Fullstack - DArtagnan Lamarca",
                        Version = "v1",
                        Description = "Teste Desenvolvedor Fullstack - DArtagnan Lamarca",
                        Contact = new OpenApiContact
                        {
                            Name = "DArtagnan Lamarca",
                            Url = new Uri("https://github.com/skaiwolker")
                        }
                    });
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Tarefa, TarefaGetDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Titulo))
                .ForMember(dest => dest.Prioridade, opt => opt.MapFrom(src => src.Prioridade.Titulo));
                mc.CreateMap<TarefaDTO, Tarefa>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();

            services.AddDependencyInjection(Configuration);

            services.AddDbContext<TarefaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TarefaContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste Desenvolvedor Fullstack - DArtagnan Lamarca");
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
