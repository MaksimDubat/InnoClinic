using InnoClinic.AccountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.AccountService.Infrastructure.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
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

        builder.Property(x => x.IsLinkedToAccount)
               .HasDefaultValue(false)
               .IsRequired();

        builder.Property(x => x.AccountId)
               .IsRequired();

        builder.HasOne(x => x.Account)
               .WithOne(x => x.Patient)
               .HasForeignKey<Patient>(x => x.AccountId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
    }
}
