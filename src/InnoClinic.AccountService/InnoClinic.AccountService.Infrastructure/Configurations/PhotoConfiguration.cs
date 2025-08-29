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
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Url)
                   .HasMaxLength(126)
                   .IsRequired();

            builder.HasOne(x => x.Office)
                   .WithOne(x => x.Photo)
                   .HasForeignKey<Office>(x => x.PhotoId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Accounts)
                   .WithOne(x => x.Photo) 
                   .HasForeignKey(x => x.PhotoId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
