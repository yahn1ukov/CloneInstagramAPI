using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Post
{
    public class PostCommentCannotBeDeletedException : CustomException
    {
        public PostCommentCannotBeDeletedException()
            : base(400, "Comment cannot be deleted.") { }
    }
}