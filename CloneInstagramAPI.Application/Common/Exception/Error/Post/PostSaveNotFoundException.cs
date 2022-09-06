using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Post
{
    public class PostSaveNotFoundException : CustomException
    {
        public PostSaveNotFoundException()
            : base(404, "Save not found.") { }
    }
}