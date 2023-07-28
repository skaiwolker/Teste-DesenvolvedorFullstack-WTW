using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Prioridade> Prioridades { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
