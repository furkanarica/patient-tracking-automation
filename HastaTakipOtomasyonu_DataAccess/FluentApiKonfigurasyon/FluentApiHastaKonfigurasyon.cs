using HastaTakipOtomasyonu_Model.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_DataAccess.FluentApiKonfigurasyon
{
    public class FluentApiHastaKonfigurasyon : IEntityTypeConfiguration<Hasta>
    {
        public void Configure(EntityTypeBuilder<Hasta> modelBuilder)
        {
            modelBuilder.Property(a=>a.HastaTc).IsRequired().HasMaxLength(11);
            modelBuilder.Property(a => a.HastaAdı).IsRequired();
            modelBuilder.Property(a => a.HastaSoyadı).IsRequired();
            modelBuilder.Property(a => a.HastaDogumTarihi).IsRequired();
            modelBuilder.Property(a => a.HastaDogumYeri).IsRequired();
            modelBuilder.Property(a => a.HastaCinsiyet).IsRequired();
            modelBuilder.Property(a => a.KanGrubu).IsRequired();
            modelBuilder.Property(a => a.HastaAdres).IsRequired();
            modelBuilder.Property(a => a.HastaTelefon).IsRequired().HasMaxLength(11);
            modelBuilder.Property(a => a.HastaGirisTarihi).IsRequired();
            modelBuilder.Ignore(a => a.HastaAdSoyad);

            modelBuilder.HasOne(a => a.Muayene).WithOne(a => a.Hasta).HasForeignKey<Hasta>("MuayeneId");

            modelBuilder.HasOne(a=>a.Klinik).WithMany(a=>a.Hasta).HasForeignKey(a=>a.KlinikId);
            modelBuilder.HasOne(a => a.Doktor).WithMany(a => a.Hasta).HasForeignKey(a => a.DoktorId);
        }
    }
}
