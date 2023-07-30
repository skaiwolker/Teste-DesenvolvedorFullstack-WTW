using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;

namespace Service.Services.Base

{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(Tarefa entity)
        {
            var dbEntity = await _repository.GetById(entity.Id);

            if (dbEntity != null)
                throw new ArgumentNullException(nameof(entity));

            entity.StatusId = (int)Enumerations.Status.NaoIniciada;

            await _repository.Add(entity);
        }

        public async Task Delete(Guid Id)
        {
            var entity = await _repository.GetById(Id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _repository.Delete(entity);
        }

        public async Task<List<Tarefa>> GetTarefasWithAllDetails()
        {
            return await _repository.GetTarefasWithAllDetails();
        }

        public async Task IniciarTarefa(Guid Id)
        {
            var entity = await _repository.GetById(Id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.StatusId = (int)Enumerations.Status.EmAndamento;
            entity.DataDeInicio = DateTime.Now;

            await _repository.AtualizarStatus(entity);
        }

        public async Task ConcluirTarefa(Guid Id)
        {
            var entity = await _repository.GetById(Id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.StatusId = (int)Enumerations.Status.Concuida;
            entity.DataDeConclusao = DateTime.Now;

            await _repository.AtualizarStatus(entity);
        }
    }
}
