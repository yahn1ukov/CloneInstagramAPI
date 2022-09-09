using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IMessageRepository : IActionRepository<Message>
    {
        Task<Message?> GetById(Guid messageId);
        Task<ICollection<Message>> GetAllById(Guid roomId);
        Task Change(Message message);
    }
}