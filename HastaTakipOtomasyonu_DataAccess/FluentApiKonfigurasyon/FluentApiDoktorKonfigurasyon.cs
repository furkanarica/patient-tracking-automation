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
    public class FluentApiDoktorKonfigurasyon : IEntityTypeConfiguration<Doktor>
    {
        public void Configure(EntityTypeBuilder<Doktor> modelBuilder) 
        {
            modelBuilder.Property(a=>a.DoktorAd).IsRequired();
            modelBuilder.Property(a=>a.DoktorSoyad).IsRequired();
            modelBuilder.Property(a=>a.DoktorTc).IsRequired().HasMaxLength(11);
            modelBuilder.Ignore(a=>a.DoktorAdSoyad);
            modelBuilder.HasOne(a => a.Klinik).WithMany(a => a.Doktor).HasForeignKey(a => a.KlinikId);
        }
    }
}
