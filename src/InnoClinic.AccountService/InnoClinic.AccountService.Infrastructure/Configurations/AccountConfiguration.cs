using InnoClinic.AccountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InnoClinic.AccountService.Infrastructure.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .HasMaxLength(126)
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Password)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.IsEmailVerified)
                .IsRequired();

            builder.Property(x => x.PhotoId)
                .IsRequired(false);

            builder.Property(x => x.CreatedBy)
                .HasMaxLength(126)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            builder.Property(a => a.UpdatedBy)
                .HasMaxLength(126)
                .IsRequired();

            builder.Property(a => a.UpdatedAt)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.HasOne(a => a.Photo)
                .WithMany(p => p.Accounts)
                .HasForeignKey(a => a.PhotoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.Doctor)
                .WithOne(d => d.Account)
                .HasForeignKey<Doctor>(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Patient)
                .WithOne(p => p.Account)
                .HasForeignKey<Patient>(p => p.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Receptionist)
                .WithOne(r => r.Account)
                .HasForeignKey<Receptionist>(r => r.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
