using InnoClinic.AccountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoClinic.AccountService.Infrastructure.Configurations;

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

        builder.Property(x => x.UpdatedBy)
            .HasMaxLength(126)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder.HasOne(x => x.Photo)
            .WithMany(x => x.Accounts)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Doctor)
            .WithOne(x => x.Account)
            .HasForeignKey<Doctor>(x => x.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Patient)
            .WithOne(x => x.Account)
            .HasForeignKey<Patient>(x => x.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Receptionist)
            .WithOne(x => x.Account)
            .HasForeignKey<Receptionist>(x => x.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
