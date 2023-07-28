using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository.Base
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task Delete(T entity);

    }
}
