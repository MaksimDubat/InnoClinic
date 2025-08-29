using InnoClinic.AccountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoClinic.AccountService.Infrastructure.Configurations;

public class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Address)
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(x => x.PhotoId)
               .IsRequired(false);

        builder.Property(x => x.RegistryPhoneNumber)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(x => x.IsActive)
               .HasDefaultValue(true)
               .IsRequired();

        builder.HasOne(x => x.Photo)
               .WithOne(x => x.Office)
               .HasForeignKey<Office>(x => x.PhotoId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Doctors)
               .WithOne(x => x.Office)
               .HasForeignKey(x => x.OfficeId);

        builder.HasMany(x => x.Receptionists)
               .WithOne(x => x.Office)
               .HasForeignKey(x => x.OfficeId);
    }   
}
