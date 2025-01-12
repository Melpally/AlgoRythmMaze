namespace AlgoRythmMaze.Domain.Interfaces
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        public Task DeleteAsync(int id);
        public Task<bool> CreateAsync(TEntity entity);
        public Task<bool> UpdateAsync(TEntity entity);
        public ValueTask<TEntity> GetByIdAsync(int id);
    }
}
