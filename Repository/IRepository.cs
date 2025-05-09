using CinemaApp.Domain;

namespace CinemaApp.Repository;

public interface IRepository<E> where E : Entity
{
    Task<E?> GetByIdAsync(int id);
    Task<IEnumerable<E>> GetAllAsync();
    Task AddAsync(E entity);
    Task UpdateAsync(E entity);
    Task DeleteAsync(int id);
}
