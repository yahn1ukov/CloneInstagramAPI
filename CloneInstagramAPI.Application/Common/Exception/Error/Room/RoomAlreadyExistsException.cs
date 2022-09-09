using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Room
{
    public class RoomAlreadyExistsException : CustomException
    {
        public RoomAlreadyExistsException()
            : base(400, "Room already exists.") { }
    }
}