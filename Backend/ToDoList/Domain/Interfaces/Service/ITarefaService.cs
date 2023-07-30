using Domain.Entities;

namespace Domain.Interfaces.Service
{
    public interface ITarefaService
    {
        Task Add(Tarefa entity);
        Task Delete(Guid Id);
        Task<List<Tarefa>> GetTarefasWithAllDetails();
        Task IniciarTarefa(Guid Id);
        Task ConcluirTarefa(Guid Id);
    }
}
