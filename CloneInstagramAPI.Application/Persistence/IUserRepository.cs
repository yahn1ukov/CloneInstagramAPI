﻿using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IUserRepository
    {
        Task<bool> FindByEmail(string email);
        Task Create(User user);
        Task<User?> Get(Guid id);
        Task<User?> GetByUserName(string username);
        Task<IEnumerable<User>> GetAll();
        Task Delete(User user);
    }
}