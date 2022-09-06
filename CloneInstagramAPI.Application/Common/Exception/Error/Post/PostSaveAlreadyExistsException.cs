using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.Post
{
    public class PostSaveAlreadyExistsException : CustomException
    {
        public PostSaveAlreadyExistsException()
            : base(400, "Save already exists.") { }
    }
}