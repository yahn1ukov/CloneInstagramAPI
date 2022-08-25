using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class DeletePostByIdCommandHandler : IRequestHandler<DeletePostByIdCommand, bool>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostByIdCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> Handle(DeletePostByIdCommand command, CancellationToken cancellationToken)
        {
            if (await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            await _postRepository.Delete(post);

            return true;
        }
    }
}