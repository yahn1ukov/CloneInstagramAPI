using AutoMapper;
using CloneInstagramAPI.Application.Rooms.Common;
using CloneInstagramAPI.Contracts.Message;
using CloneInstagramAPI.Contracts.Room;

namespace CloneInstagramAPI.Api.Common.Mapper
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<GetAllRoomsResult, GetAllRoomsResponse>();
            CreateMap<GetAllMessagesResult, GetAllMessagesResponse>();
        }
    }
}