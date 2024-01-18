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
    public class FluentApiMuayeneKonfigurasyon : IEntityTypeConfiguration<Muayene>
    {
        public void Configure(EntityTypeBuilder<Muayene> modelBuilder)
        {
            modelBuilder.Property(a => a.Teshis).IsRequired();
            modelBuilder.Property(a => a.Durum).IsRequired();
            modelBuilder.Property(a => a.Sonuc).IsRequired();
            modelBuilder.Property(a => a.Test).IsRequired();
            
            modelBuilder.Property(a => a.KullanimSekli).IsRequired();
            modelBuilder.Property(a => a.BaslangicTarihi).IsRequired();
            modelBuilder.Property(a => a.BitisTarihi).IsRequired();

            modelBuilder.HasOne(a => a.EtkenMadde).WithMany(a => a.Muayene).HasForeignKey(a => a.EtkenMaddeId);
        }
    }
}
