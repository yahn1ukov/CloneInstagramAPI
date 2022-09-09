namespace CloneInstagramAPI.Application.Persistence
{
    public interface IActionRepository<T>
    {
        Task<T?> GetById(Guid entity1, Guid entity2);
        Task Add(T entity);
        Task Remove(T entity);
    }
}