using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;

namespace Service.Services.Base
{
    public class StatusService : BaseService<Status>, IStatusService
    {
        public StatusService(IStatusRepository repository) : base(repository)
        {
        }
    }
}
