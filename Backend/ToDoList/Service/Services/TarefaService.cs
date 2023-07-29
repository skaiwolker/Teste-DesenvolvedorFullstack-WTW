using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;

namespace Service.Services.Base

{
    public class TarefaService : BaseService<Tarefa>, ITarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<Tarefa>> GetTarefasWithAllDetails()
        {
            return await _repository.GetTarefasWithAllDetails();
        }
    }
}
