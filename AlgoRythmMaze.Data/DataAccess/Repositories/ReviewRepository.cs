﻿using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(DataContext context) : base(context)
        {
        }
    }
}
