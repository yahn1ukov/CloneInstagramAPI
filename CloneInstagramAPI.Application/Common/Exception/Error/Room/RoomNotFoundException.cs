using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Room
{
    public class RoomNotFoundException : CustomException
    {
        public RoomNotFoundException()
            : base(404, "Room not found.") { }
    }
}