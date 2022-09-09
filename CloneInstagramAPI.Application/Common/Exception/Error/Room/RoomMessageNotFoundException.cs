using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Room
{
    public class RoomMessageNotFoundException : CustomException
    {
        public RoomMessageNotFoundException()
            : base(404, "Message not found.") { }
    }
}