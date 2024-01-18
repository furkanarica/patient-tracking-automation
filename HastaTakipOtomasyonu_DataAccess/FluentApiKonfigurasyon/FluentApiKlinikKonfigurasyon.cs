using HastaTakipOtomasyonu_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_DataAccess.FluentApiKonfigurasyon
{
    public class FluentApiKlinikKonfigurasyon : IEntityTypeConfiguration<Klinik>
    {
        public void Configure(EntityTypeBuilder<Klinik> modelBuilder) 
        {
            modelBuilder.Property(a => a.KlinikAdi).IsRequired();
            modelBuilder.Property(a=> a.KlinikKodu).IsRequired();
        }
    }
}
