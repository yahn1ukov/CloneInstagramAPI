using CloneInstagramAPI.Application.Common.Exception.Error.Room;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Rooms.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Queries
{
    public class GetAllRoomMessagesByIdQueryHandler : IRequestHandler<GetAllRoomMessagesByIdQuery, ICollection<GetAllMessagesResult>>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMessageRepository _messageRepository;

        public GetAllRoomMessagesByIdQueryHandler
        (
            IRoomRepository roomRepository,
            IMessageRepository messageRepository
        )
        {
            _roomRepository = roomRepository;
            _messageRepository = messageRepository;
        }

        public async Task<ICollection<GetAllMessagesResult>> Handle(GetAllRoomMessagesByIdQuery query, CancellationToken cancellationToken)
        {
            if(await _roomRepository.GetById(query.RoomId) is not Room room)
            {
                throw new RoomNotFoundException();
            }

            var messages = await _messageRepository.GetAllById(room.Id);

            return messages
                .Select(m => new GetAllMessagesResult(m.Id, m.Text, m.User.Avatar, m.User.Username, m.IsEdited, m.CreatedAt))
                .ToList();
        }
    }
}