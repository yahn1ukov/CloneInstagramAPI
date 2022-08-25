﻿using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public class GetAllPostsCurrentUserByIdQueryHandler : IRequestHandler<GetAllPostsCurrentUserByIdQuery, IEnumerable<AllPostsResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public GetAllPostsCurrentUserByIdQueryHandler(IUserRepository userRepository, IPostRepository postRepository)
            _userRepository = userRepository;
            _postRepository = postRepository;
        }


        public async Task<IEnumerable<AllPostsResult>> Handle(GetAllPostsCurrentUserByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            var posts = await _postRepository.GetAllUsersById(user.Id);

            return posts
                .Select(p => new AllPostsResult(p.Id, p.Content))
                .ToList();
        }
    }
}