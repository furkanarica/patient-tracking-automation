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
    public class FluentApiGecmisMuayeneKonfigurasyon : IEntityTypeConfiguration<GecmisMuayene>
    {
        public void Configure(EntityTypeBuilder<GecmisMuayene> modelBuilder)
        {
            modelBuilder.HasOne(a => a.Klinik).WithMany(a => a.GecmisMuayene).HasForeignKey(a => a.KlinikId);
            modelBuilder.HasOne(a => a.Doktor).WithMany(a => a.GecmisMuayene).HasForeignKey(a => a.DoktorId);
            modelBuilder.HasOne(a => a.Muayene).WithOne(a => a.GecmisMuayene).HasForeignKey<GecmisMuayene>("MuayeneId");
        }
    }
}
