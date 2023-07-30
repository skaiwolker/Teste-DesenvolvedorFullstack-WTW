using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Tarefa : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataDeInicio { get; set; }
        public DateTime? DataDeConclusao { get; set; }
        public int PrioridadeId { get; set; }
        public virtual Prioridade Prioridade { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
