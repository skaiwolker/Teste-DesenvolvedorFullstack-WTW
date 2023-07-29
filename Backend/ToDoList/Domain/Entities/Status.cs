using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Status : EntityBase
    {
        public virtual List<Tarefa> Tarefas { get; set; }
    }
}
