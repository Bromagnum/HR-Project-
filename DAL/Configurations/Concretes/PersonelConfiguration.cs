using DAL.Configurations.Abstracts;
using DAL.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations.Concretes
{
    internal class PersonelConfiguration : BaseConfiguration<Personel>
    {
        public override void Configure(EntityTypeBuilder<Personel> builder)
        {
            base.Configure(builder);
            // Personel-specific configurations
            builder.Property(x => x.Ad)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.SoyAd)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.TelefonNo)
                .HasMaxLength(15);
            builder.Property(x => x.TCNo)
                .HasMaxLength(15);
            builder.Property(x => x.DogumTarihi)
        .HasColumnType("date");
            builder.Property(x => x.EgitimDurumu)
                .HasMaxLength(100);
            builder.Property(x => x.SGKNo)
                .HasMaxLength(20);
            builder.Property(x => x.Maas)
                .HasColumnType("decimal(18,2)");
            builder.Property(x => x.KanGrubu)
                .IsRequired()
                .HasMaxLength(10);
            // Mapping    
            builder.HasOne(x => x.GorevYeri)
                .WithMany(y => y.Personeller)
                .HasForeignKey(x => x.GorevYeriId);
            builder.HasMany(x => x.Nitelikler)
                .WithOne(y => y.Personel)
                .HasForeignKey(y => y.PersonelId);
            builder.HasMany(x => x.Degerlendirmeler)
                .WithOne(y => y.Personel)
                .HasForeignKey(y => y.PersonelId);
            builder.HasMany(x => x.Mesailer)
                .WithOne(y => y.Personel)
                .HasForeignKey(y => y.PersonelId);
            builder.HasMany(x => x.Izinler)
                .WithOne(y => y.Personel)
                .HasForeignKey(y => y.PersonelId);

            base.Configure(builder);
        }
    }
}
