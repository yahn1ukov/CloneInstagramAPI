namespace CloneInstagramAPI.Application.Persistence
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task Update(T entity);
        Task Delete(T entity);
    }
}