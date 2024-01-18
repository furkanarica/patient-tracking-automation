using HastaTakipOtomasyonu_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_DataAccess.FluentApiKonfigurasyon
{
    public class FluentApiKullaniciKonfigurasyon : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> modelBuilder)
        {
            modelBuilder.HasOne(a => a.Yetki).WithMany(a => a.Kullanici).HasForeignKey(a => a.YetkiId);
            modelBuilder.Property(a => a.KullaniciAdi).IsRequired();
            modelBuilder.Property(a => a.Sifre).IsRequired();
            modelBuilder.Property(a => a.TcNo).IsRequired().HasMaxLength(11);
            modelBuilder.Property(a => a.Ad).IsRequired();
            modelBuilder.Property(a => a.Soyad).IsRequired();
            modelBuilder.Property(a => a.Mail).IsRequired();
            modelBuilder.Property(a => a.Telefon).IsRequired().HasMaxLength(11);
            modelBuilder.Property(a => a.Cinsiyet).IsRequired();
            modelBuilder.Property(a => a.Adres).IsRequired();
            modelBuilder.Property(a => a.DogumTarihi).IsRequired();
        }
    }
}
