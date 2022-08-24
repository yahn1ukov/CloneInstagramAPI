using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Post
{
    public class PostNotFoundException : CustomException
    {
        public PostNotFoundException()
            : base(404, "Post not found.") { }
    }
}