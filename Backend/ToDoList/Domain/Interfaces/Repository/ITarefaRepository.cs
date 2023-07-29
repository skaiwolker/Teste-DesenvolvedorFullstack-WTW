using Domain.Entities;
using Domain.Interfaces.Repository.Base;

namespace Domain.Interfaces.Repository
{
    public interface ITarefaRepository : IBaseRepository<Tarefa>
    {
        Task<List<Tarefa>> GetTarefasWithAllDetails();
    }
}
