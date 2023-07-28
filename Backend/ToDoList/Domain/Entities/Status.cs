using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Status : EntityBase
    {
        public virtual List<Tarefa> Tarefas { get; set; }
    }
}
