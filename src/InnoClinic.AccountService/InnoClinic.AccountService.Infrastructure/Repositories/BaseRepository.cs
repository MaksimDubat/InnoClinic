using InnoClinic.AccountService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InnoClinic.AccountService.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AccountServiceDbContext _context;

    public BaseRepository(AccountServiceDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity, CancellationToken cancellation)
    {
        await _context.Set<T>().AddAsync(entity, cancellation);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .AnyAsync(predicate, cancellation);
    }

    public async Task<T> DeleteAsync(int id, CancellationToken cancellation)
    {
        T? entity = await _context.Set<T>().FindAsync(id, cancellation);
        _context.Remove(entity!);

        return entity!;
    }

    public async Task<List<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> queryBuilder, CancellationToken cancellation)
    {
        IQueryable<T> query = queryBuilder(_context.Set<T>().AsNoTracking());

        return await query.ToListAsync(cancellation);
    }

    public async Task<T> GetAsync(int id, CancellationToken cancellation)
    {
        return await _context.Set<T>().FindAsync(id, cancellation);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }
}
