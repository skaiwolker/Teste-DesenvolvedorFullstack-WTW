using Domain.Entities;
using Domain.Interfaces.Service.Base;

namespace Domain.Interfaces.Service
{
    public interface ITarefaService : IBaseService<Tarefa>
    {
        Task<List<Tarefa>> GetTarefasWithAllDetails();
    }
}
