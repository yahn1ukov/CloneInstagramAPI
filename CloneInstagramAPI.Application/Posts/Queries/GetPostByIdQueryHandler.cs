using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public GetPostByIdQueryHandler(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task<PostResult> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if (await _postRepository.GetById(query.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            if (post.UserId is null)
            {
                throw new PostNotFoundException();
            }

            var isLike = post.Likes.Any(l => l.UserId == user.Id) ? true : false;
            var countLikes = post.Likes.Count > 0 ? post.Likes.Count : 0;

            var isSave = post.Saves.Any(s => s.UserId == user.Id) ? true : false;
            var countSaves = post.Saves.Count > 0 ? post.Saves.Count : 0;

            var comments = post.Comments
                                .Select(c => new AllPostCommentsResult(c.Id, c.Message, c.CreatedAt))
                                .ToList();
            var countComments = post.Comments.Count > 0 ? post.Comments.Count : 0;

            return new PostResult
            (
                post.Id,
                post.Content,
                post.Description,
                post.User.Avatar,
                post.User.Username,
                countLikes,
                countSaves,
                countComments,
                comments,
                isLike,
                isSave,
                post.CreatedAt
            );
        }
    }
}