using DAL.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations.Abstracts
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            // Created properties
            builder.Property(x => x.CreatedComputerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CreatedIpAddress)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Updated properties
            builder.Property(x => x.UpdatedComputerName)
                .HasMaxLength(100);

            builder.Property(x => x.UpdatedIpAddress)
                .HasMaxLength(50);

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false);

            // Deleted properties
            builder.Property(x => x.DeletedComputerName)
                .HasMaxLength(100);

            builder.Property(x => x.DeletedIpAddress)
                .HasMaxLength(50);
            builder.Property(x => x.DeletedDate).IsRequired(false);


        }
    }
}
