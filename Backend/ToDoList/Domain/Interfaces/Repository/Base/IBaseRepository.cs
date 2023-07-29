using Domain.Entities.Base;

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
