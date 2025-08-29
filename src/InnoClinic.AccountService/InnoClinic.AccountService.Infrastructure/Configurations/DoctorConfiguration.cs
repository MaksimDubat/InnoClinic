using InnoClinic.AccountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoClinic.AccountService.Infrastructure.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.FirstName)
                   .HasMaxLength(126)
                   .IsRequired();

            builder.Property(d => d.LastName)
                   .HasMaxLength(126)
                   .IsRequired();

            builder.Property(d => d.MiddleName)
                   .HasMaxLength(126)
                   .IsRequired();

            builder.Property(d => d.DateOfBirth)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(d => d.CareerStartYear)
                   .IsRequired();

            builder.Property(d => d.Status)
                   .HasMaxLength(126)
                   .IsRequired();

            builder.HasOne(d => d.Account)
                   .WithOne(a => a.Doctor) 
                   .HasForeignKey<Doctor>(d => d.AccountId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Specialization)
                   .WithMany(s => s.Doctors)
                   .HasForeignKey(d => d.SpecializationId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(d => d.Office)
                   .WithMany(o => o.Doctors)
                   .HasForeignKey(d => d.OfficeId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
