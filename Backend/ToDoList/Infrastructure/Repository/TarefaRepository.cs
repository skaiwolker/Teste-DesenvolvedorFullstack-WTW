using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly IDbConnection _connection;
        private readonly TarefaContext _context;
        public TarefaRepository(TarefaContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
        }

        public async Task Add(Tarefa entity)
        {
            _context.Tarefa.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Tarefa entity)
        {
            _context.Tarefa.Remove(entity);
            await _context.SaveChangesAsync();
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

        public async Task<Tarefa> GetById(Guid id)
        {
            string query = $"SELECT * FROM Tarefa WHERE Id = '{id}'";

            var result = await _connection.QueryFirstOrDefaultAsync<Tarefa>(query);

            return result;
        }

        public async Task AtualizarStatus(Tarefa entity)
        {
            _context.Tarefa.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
