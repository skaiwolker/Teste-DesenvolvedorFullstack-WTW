using Domain.Entities.Base;

namespace Domain.Interfaces.Service.Base
{
    public interface IBaseService<T> where T : EntityBase
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task Delete(Guid Id);
    }
}
