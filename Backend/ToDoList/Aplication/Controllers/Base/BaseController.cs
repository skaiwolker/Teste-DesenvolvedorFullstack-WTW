using Domain.Entities.Base;
using Domain.Interfaces.Service.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aplication.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : EntityBase
    {
        private readonly IBaseService<T> _service;

        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] T obj)
        {
            try
            {
                await _service.Add(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<T>> GetById(Guid id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<T>>> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
