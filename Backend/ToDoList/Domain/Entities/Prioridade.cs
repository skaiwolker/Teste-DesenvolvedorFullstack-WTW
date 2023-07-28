using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Prioridade : EntityBase
    {
        public virtual List<Tarefa> Tarefas { get; set; }
    }
}
