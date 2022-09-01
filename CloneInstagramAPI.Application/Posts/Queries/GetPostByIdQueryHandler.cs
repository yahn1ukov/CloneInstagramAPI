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
            if (await _postRepository.GetById(query.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            if (await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            int countLikes = post.Likes.Count > 0 ? post.Likes.Count : 0;
            int countSaves = post.Saves.Count > 0 ? post.Saves.Count : 0;

            bool isLike = post.Likes.Contains(user.Id) ? true : false;
            bool isSave = post.Saves.Contains(user.Id) ? true : false;

            return new PostResult
            (
                post.Id,
                post.Content,
                post.Description,
                post.User.Avatar,
                post.User.Username,
                countLikes,
                countSaves,
                isLike,
                isSave,
                post.CreatedAt
            );
        }
    }
}