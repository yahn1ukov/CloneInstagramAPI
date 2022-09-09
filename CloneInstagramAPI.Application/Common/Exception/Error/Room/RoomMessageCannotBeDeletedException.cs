using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Room
{
    public class RoomMessageCannotBeDeletedException : CustomException
    {
        public RoomMessageCannotBeDeletedException()
            : base(400, "Message cannot be deleted.") { }
    }
}