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
    public class StatusService : BaseService<Status>, IStatusService
    {
        public StatusService(IStatusRepository repository) : base(repository)
        {        
        }
    }
}
