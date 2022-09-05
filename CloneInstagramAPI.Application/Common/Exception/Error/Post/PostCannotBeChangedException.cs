using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Post
{
    public class PostCannotBeChangedException : CustomException
    {
        public PostCannotBeChangedException()
            : base(400, "Post cannot be changed.") { }
    }
}