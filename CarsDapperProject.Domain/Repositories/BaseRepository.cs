using CarsDapperProject.Domain.Entities;

namespace CarsDapperProject.Domain.Repositories;

public abstract class BaseRepository<T> : IRepository<T>
    where T : IEntity
{
    public virtual Task<int> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IReadOnlyList<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public virtual Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public virtual Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
