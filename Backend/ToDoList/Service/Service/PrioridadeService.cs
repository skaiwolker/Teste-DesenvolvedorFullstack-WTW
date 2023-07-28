using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Service.Service.Base;

namespace Service.Service
{
    public class PrioridadeService : BaseService<Prioridade>, IPrioridadeService
    {
        public PrioridadeService(IPrioridadeRepository repository) : base(repository)
        {
        }
    }
}
