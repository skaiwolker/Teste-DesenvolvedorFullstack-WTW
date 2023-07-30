namespace Domain.DTOs
{
    public class TarefaDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int PrioridadeId { get; set; }
    }
}
