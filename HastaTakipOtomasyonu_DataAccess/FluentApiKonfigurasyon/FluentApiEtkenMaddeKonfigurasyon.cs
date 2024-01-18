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
    public class FluentApiEtkenMaddeKonfigurasyon : IEntityTypeConfiguration<EtkenMadde>
    {
        public void Configure(EntityTypeBuilder<EtkenMadde> modelBuilder)
        {
            modelBuilder.Property(a => a.EtkenKodu).IsRequired();
            modelBuilder.Property(a => a.EtkenAdi).IsRequired();
        }
    }
}
