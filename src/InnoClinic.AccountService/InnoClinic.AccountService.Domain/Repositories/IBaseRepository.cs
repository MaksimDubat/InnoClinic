using System.Linq.Expressions;

namespace InnoClinic.AccountService.Application.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> queryBuilder, CancellationToken cancellation);
    Task<T> GetAsync(int id, CancellationToken cancellation);
    Task AddAsync(T entity, CancellationToken cancellation);
    void Update(T entity);
    Task<T> DeleteAsync(int id, CancellationToken cancellation);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation);
}
