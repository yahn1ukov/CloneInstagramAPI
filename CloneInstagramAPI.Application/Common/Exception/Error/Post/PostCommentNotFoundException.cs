using System.Numerics;
using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Post
{
    public class PostCommentNotFoundException : CustomException
    {
        public PostCommentNotFoundException()
            : base(404, "Comment not found.") { }
    }
}