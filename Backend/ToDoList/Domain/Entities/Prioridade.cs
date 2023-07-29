using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Prioridade : EntityBase
    {
        public virtual List<Tarefa> Tarefas { get; set; }
    }
}
