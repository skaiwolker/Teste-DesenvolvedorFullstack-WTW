using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(TarefaContext context, IConfiguration configuration) : base(context, configuration)
        {

        }
    }
}
