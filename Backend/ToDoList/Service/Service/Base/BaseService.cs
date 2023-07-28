using Domain.Entities.Base;
using Domain.Interfaces.Repository.Base;
using Domain.Interfaces.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : EntityBase
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Add(T entity)
        {
            var dbEntity = await _repository.GetById(entity.Id);

            if (dbEntity != null)
                throw new ArgumentNullException(nameof(entity));

            await _repository.Add(entity);
        }

        public async Task Delete(Guid Id)
        {
            var entity = await _repository.GetById(Id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _repository.Delete(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
