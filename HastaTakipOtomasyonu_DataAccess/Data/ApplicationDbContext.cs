using HastaTakipOtomasyonu_DataAccess.FluentApiKonfigurasyon;
using HastaTakipOtomasyonu_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
           
        }       
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Yetki> Yetkiler { get; set; }
        public DbSet<Klinik> Klinikler { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Muayene> Muayeneler { get; set; }
        public DbSet<EtkenMadde> EtkenMaddeler { get; set; }
        public DbSet<BekleyenIslem> BekleyenIslemler { get; set; }
        public DbSet<GecmisMuayene> GecmisMuayeneler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentApiKullaniciKonfigurasyon());
            modelBuilder.ApplyConfiguration(new FluentApiKlinikKonfigurasyon());
            modelBuilder.ApplyConfiguration(new FluentApiDoktorKonfigurasyon());
            modelBuilder.ApplyConfiguration(new FluentApiHastaKonfigurasyon());
            modelBuilder.ApplyConfiguration(new FluentApiMuayeneKonfigurasyon());
            modelBuilder.ApplyConfiguration(new FluentApiEtkenMaddeKonfigurasyon());
            modelBuilder.ApplyConfiguration(new FluentApiBekleyenIslemKonfigurasyon());
            modelBuilder.ApplyConfiguration(new FluentApiGecmisMuayeneKonfigurasyon());
        }
    }
}
 