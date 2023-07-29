using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repository
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        private readonly IDbConnection _connection;
        public TarefaRepository(TarefaContext context, IConfiguration configuration) : base(context, configuration)
        {
            _connection = _connection.AddConnection(configuration);
        }

        public async Task<List<Tarefa>> GetTarefasWithAllDetails()
        {
            var query = @"SELECT * FROM Tarefa AS T
                          LEFT JOIN Prioridade AS P ON P.Id = T.PrioridadeId
                          LEFT JOIN Status AS S On S.Id = T.StatusId";

            var result = await _connection.QueryAsync<Tarefa, Prioridade, Status, Tarefa>(query, (tarefa, prioridade, status) =>
            {
                tarefa.Prioridade = prioridade;
                tarefa.Status = status;
                return tarefa;
            });

            return result.ToList();
        }
    }
}
