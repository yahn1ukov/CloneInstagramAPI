﻿using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllWithoutUser();
        Task<IEnumerable<Post>> GetAllUsersById(Guid id);
    }
}