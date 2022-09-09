using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Room
{
    public class RoomMessageCannotBeChangedException : CustomException
    {
        public RoomMessageCannotBeChangedException()
            : base(400, "Message cannot be changed.") { }
    }
}