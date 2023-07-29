using AutoMapper;
using Domain.DTOs.Base;
using Domain.Entities.Base;
using Domain.Interfaces.Service.Base;
using Microsoft.AspNetCore.Mvc;

namespace Aplication.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<T, TDTO> : ControllerBase where TDTO : BaseDTO where T : EntityBase
    {
        private readonly IBaseService<T> _service;
        private readonly IMapper _mapper;

        public BaseController(IBaseService<T> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TDTO obj)
        {
            try
            {
                var dbObj = _mapper.Map<T>(obj); 
                await _service.Add(dbObj);
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
        public async Task<ActionResult<TDTO>> GetById(Guid id)
        {
            try
            {
                var obj = _mapper.Map<TDTO>(await _service.GetById(id));
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TDTO>>> GetAll()
        {
            try
            {
                var obj = _mapper.Map<List<TDTO>>(await _service.GetAll());
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
