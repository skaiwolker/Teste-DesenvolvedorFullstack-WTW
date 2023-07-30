using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Status : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public virtual List<Tarefa> Tarefas { get; set; }
    }
}
