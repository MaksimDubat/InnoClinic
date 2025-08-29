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
    public class ReceptionistConfiguration : IEntityTypeConfiguration<Receptionist>
    {
        public void Configure(EntityTypeBuilder<Receptionist> builder)
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

            builder.Property(x => x.AccountId)
                   .IsRequired();

            builder.Property(x => x.OfficeId)
                    .IsRequired(false);

            builder.HasOne(x => x.Account)
                   .WithOne(x => x.Receptionist) 
                   .HasForeignKey<Receptionist>(x => x.AccountId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();

            builder.HasOne(x => x.Office)
                   .WithMany(x => x.Receptionists)
                   .HasForeignKey(x => x.OfficeId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
