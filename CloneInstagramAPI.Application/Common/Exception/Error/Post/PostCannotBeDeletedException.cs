using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Post
{
    public class PostCannotBeDeletedException : CustomException
    {
        public PostCannotBeDeletedException()
            : base(400, "Post cannot be deleted.") {}
    }
}