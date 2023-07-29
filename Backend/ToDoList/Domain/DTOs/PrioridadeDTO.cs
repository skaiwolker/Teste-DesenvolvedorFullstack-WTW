using Domain.DTOs.Base;

namespace Domain.DTOs
{
    public class PrioridadeDTO : BaseDTO
    {
        public virtual List<TarefaDTO> Tarefas { get; set; }
    }
}
