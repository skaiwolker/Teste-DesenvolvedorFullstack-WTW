namespace Domain.DTOs
{
    public class TarefaGetDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataDeInicio { get; set; }
        public DateTime? DataDeConclusao { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
    }
}
