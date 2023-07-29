using Aplication.Controllers.Base;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Aplication.Controllers
{
    public class PrioridadeController : BaseController<Prioridade,PrioridadeDTO>
    {
        public PrioridadeController(IPrioridadeService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
