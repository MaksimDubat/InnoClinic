using InnoClinic.AccountService.Domain.Repositories;

namespace InnoClinic.AccountService.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AccountServiceDbContext _context;

    public UnitOfWork(AccountServiceDbContext context)
    {
        _context = context;
    }

    public async Task<int> CompleteAsync(CancellationToken cancellation)
    {
        return await _context.SaveChangesAsync(cancellation);
    }
}
