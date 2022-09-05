namespace CloneInstagramAPI.Application.Persistence
{
    public interface IPostActionRepository<T>
    {
        Task<T> Get(Guid userId, Guid postId);
        Task Add(T entity);
        Task Remove(T entity);
    }
}