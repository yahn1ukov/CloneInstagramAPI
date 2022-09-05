namespace CloneInstagramAPI.Application.Persistence
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task<T?> GetById(Guid id);
        Task Update(T entity);
        Task Delete(T entity);
    }
}