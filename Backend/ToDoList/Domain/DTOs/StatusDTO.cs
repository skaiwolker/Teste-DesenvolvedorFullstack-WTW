using Domain.DTOs.Base;

namespace Domain.DTOs
{
    public class StatusDTO : BaseDTO
    {
        public virtual List<TarefaDTO> Tarefas { get; set; }
    }
}
