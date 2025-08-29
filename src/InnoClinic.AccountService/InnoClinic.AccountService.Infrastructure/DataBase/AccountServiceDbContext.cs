using InnoClinic.AccountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.AccountService.Domain.DataBase;

public class AccountServiceDbContext : DbContext
{
    public AccountServiceDbContext(DbContextOptions<AccountServiceDbContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Receptionist> Receptionists { get; set; }
    public DbSet<Specialization> Specializations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountServiceDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

}
