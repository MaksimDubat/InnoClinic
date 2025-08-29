using InnoClinic.AccountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoClinic.AccountService.Infrastructure.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
               .HasMaxLength(126)
               .IsRequired();

        builder.Property(x => x.LastName)
               .HasMaxLength(126)
               .IsRequired();

        builder.Property(x => x.MiddleName)
               .HasMaxLength(126)
               .IsRequired();

        builder.Property(x => x.DateOfBirth)
               .HasColumnType("date")
               .IsRequired();

        builder.Property(x => x.CareerStartYear)
               .IsRequired();

        builder.Property(x => x.Status)
               .HasMaxLength(126)
               .IsRequired();

        builder.HasOne(x => x.Account)
               .WithOne(x => x.Doctor) 
               .HasForeignKey<Doctor>(x => x.AccountId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Specialization)
               .WithMany(x => x.Doctors)
               .HasForeignKey(x => x.SpecializationId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Office)
               .WithMany(x => x.Doctors)
               .HasForeignKey(x => x.OfficeId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
