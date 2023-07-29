using Aplication.Controllers.Base;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Aplication.Controllers
{
    public class TarefaController : BaseController<Tarefa,TarefaDTO>
    {
        private readonly ITarefaService _service;
        private readonly IMapper _mapper;
        public TarefaController(ITarefaService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetTarefasWithAllDetails")]
        public async Task<ActionResult<List<TarefaDTO>>> GetTarefasWithAllDetails()
        {
            try
            {
                var obj = _mapper.Map<List<TarefaDTO>>(await _service.GetTarefasWithAllDetails());
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

    }
}
