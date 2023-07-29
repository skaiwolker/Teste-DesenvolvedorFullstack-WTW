using Aplication.Controllers.Base;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Aplication.Controllers
{
    public class StatusController : BaseController<Status,StatusDTO>
    {
        public StatusController(IStatusService service,  IMapper mapper) : base(service, mapper)
        {

        }
    }
}
