﻿using AlgoRythmMaze.Domain.Models;

namespace AlgoRythmMaze.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<string?> GetNameByIdAsync(int id);
    }
}
