using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Post
{
    public class PostLikeAlreadyExistsException : CustomException
    {
        public PostLikeAlreadyExistsException()
            : base(400, "Like already exists.") { }
    }
}