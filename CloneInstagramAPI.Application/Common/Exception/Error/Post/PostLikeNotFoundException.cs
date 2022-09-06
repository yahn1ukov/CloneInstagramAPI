using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Post
{
    public class PostLikeNotFoundException : CustomException
    {
        public PostLikeNotFoundException()
            : base(404, "Like not found.") { }
    }
}