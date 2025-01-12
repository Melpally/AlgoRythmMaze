﻿using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly Data.DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(Data.DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("The argument provided did not match existing data.");
            }
            else
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new ArgumentException("The argument provided did not match existing data.");
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                //TODO: log errors elsewhere
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
    }
}
