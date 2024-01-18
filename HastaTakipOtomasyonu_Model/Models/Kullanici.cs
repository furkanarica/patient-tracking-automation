using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_Model.Models
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        
        [Required]
        public string KullaniciAdi { get; set; }
        
        [Required]
        public string Sifre { get; set; }
       
        [Required]
        public string TcNo { get; set; }
        
        [Required]
        public string Ad { get; set; }
        
        [Required]
        public string Soyad { get; set; }
       
        [Required]
        public string Mail { get; set; }
        
        [Required]
        public string Telefon { get; set; }

        [Required]
        public string Cinsiyet { get; set; }

        [Required]
        public string Adres { get; set; }

        public string DogumTarihi { get; set; }

        public int YetkiId { get; set; }
        public Yetki Yetki { get; set; }

    }
}
