using Domain.DTOs.Base;

namespace Domain.DTOs
{
    public class TarefaDTO : BaseDTO
    {
        public string Descricao { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeConclusao { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
    }
}
