using HastaTakipOtomasyonu_Model.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_Model.Models
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        
        [Required]
        public string DoktorAd { get; set; }
        
        [Required]
        public string DoktorSoyad { get; set; }
        
        [Required]
        public string DoktorTc { get; set; }

        [NotMapped]
        public string DoktorAdSoyad { 
            get 
            {
                return $"{DoktorAd} {DoktorSoyad}";
            } 
        }

        public int KlinikId { get; set; }
        public Klinik Klinik { get; set; }

        public List<Hasta> Hasta { get; set; }

        public List<BekleyenIslem> BekleyenIslem { get; set; }
        
        public List<GecmisMuayene> GecmisMuayene { get; set; }
    }
}
