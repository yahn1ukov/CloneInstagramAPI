using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Rooms.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Queries
{
    public class GetAllRoomsUserByHttpContextIdQueryHandler : IRequestHandler<GetAllRoomsUserByHttpContextIdQuery, ICollection<GetAllRoomsResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;

        public GetAllRoomsUserByHttpContextIdQueryHandler
        (
            IUserRepository userRepository,
            IRoomRepository roomRepository
        )
        {
            _userRepository = userRepository;
            _roomRepository = roomRepository;
        }

        public async Task<ICollection<GetAllRoomsResult>> Handle(GetAllRoomsUserByHttpContextIdQuery query, CancellationToken cancellationToken)
        {
            if(await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            var rooms = await _roomRepository.GetAllById(user.Id);

            return rooms
                .Select(r => new GetAllRoomsResult(r.Id, r.PenPalUser.Avatar, r.PenPalUser.Username))
                .ToList();
        }
    }
}