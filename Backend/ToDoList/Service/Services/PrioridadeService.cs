using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Service.Services.Base;

namespace Services.Service
{
    public class PrioridadeService : BaseService<Prioridade>, IPrioridadeService
    {
        public PrioridadeService(IPrioridadeRepository repository) : base(repository)
        {
        }
    }
}
