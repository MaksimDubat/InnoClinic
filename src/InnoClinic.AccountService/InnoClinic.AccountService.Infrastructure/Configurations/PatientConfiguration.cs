using InnoClinic.AccountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.AccountService.Infrastructure.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                   .HasMaxLength(126)
                   .IsRequired();

            builder.Property(p => p.LastName)
                   .HasMaxLength(126)
                   .IsRequired();

            builder.Property(p => p.MiddleName)
                   .HasMaxLength(126)
                   .IsRequired();

            builder.Property(p => p.DateOfBirth)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(p => p.IsLinkedToAccount)
                   .HasDefaultValue(false)
                   .IsRequired();


            builder.Property(p => p.AccountId)
                   .IsRequired();

            builder.HasOne(p => p.Account)
                   .WithOne(a => a.Patient)
                   .HasForeignKey<Patient>(p => p.AccountId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
