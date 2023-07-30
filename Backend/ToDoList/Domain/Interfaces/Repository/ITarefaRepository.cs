using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface ITarefaRepository
    {
        Task Add(Tarefa entity);
        Task Delete(Tarefa entity);
        Task<List<Tarefa>> GetTarefasWithAllDetails();
        Task<Tarefa> GetById(Guid id);
        Task AtualizarStatus(Tarefa entity);
    }
}
