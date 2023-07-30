using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Aplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _service;
        private readonly IMapper _mapper;
        public TarefaController(ITarefaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetTarefasWithAllDetails")]
        public async Task<ActionResult<List<TarefaGetDTO>>> GetTarefasWithAllDetails()
        {
            try
            {
                var obj = _mapper.Map<List<TarefaGetDTO>>(await _service.GetTarefasWithAllDetails());
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] TarefaDTO obj)
        {
            try
            {
                var dbObj = _mapper.Map<Tarefa>(obj);
                await _service.Add(dbObj);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("Delete/{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpHead("IniciarTarefa")]
        public async Task<ActionResult> IniciarTarefa(Guid Id)
        {
            try
            {
                await _service.IniciarTarefa(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpHead("ConcluirTarefa")]
        public async Task<ActionResult> ConcluirTarefa(Guid Id)
        {
            try
            {
                await _service.ConcluirTarefa(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
