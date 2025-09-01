using InnoClinic.AccountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoClinic.AccountService.Infrastructure.Configurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
               .IsRequired();

        builder.Property(s => s.SpecializationName)
               .HasMaxLength(126)
               .IsRequired();

        builder.Property(s => s.IsActive)
               .HasDefaultValue(true)
               .IsRequired();

        builder.HasMany(s => s.Doctors)
               .WithOne(d => d.Specialization)
               .HasForeignKey(d => d.SpecializationId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
