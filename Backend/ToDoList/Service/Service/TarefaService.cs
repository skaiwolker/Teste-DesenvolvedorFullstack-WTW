using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Service.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class TarefaService : BaseService<Tarefa>, ITarefaService
    {
        public TarefaService(ITarefaRepository repository) : base(repository)
        {
        }
    }
}
