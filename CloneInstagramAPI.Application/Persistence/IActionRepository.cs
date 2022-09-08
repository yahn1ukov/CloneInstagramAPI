namespace CloneInstagramAPI.Application.Persistence
{
    public interface IActionRepository<T>
    {
        Task<T?> Get(Guid entity1, Guid entity2);
        Task<ICollection<T>> GetAll(Guid entity);
        Task<ICollection<T>> GetAll();
        Task Add(T entity);
        Task Remove(T entity);
    }
}