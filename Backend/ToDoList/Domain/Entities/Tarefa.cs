using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Tarefa : EntityBase
    {
        public string Descricao { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeConclusao { get; set; }
        public Guid PrioridadeId { get; set; }
        public virtual Prioridade Prioridade { get; set; }
        public Guid StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
