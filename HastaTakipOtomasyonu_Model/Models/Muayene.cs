using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_Model.Models
{
    public class Muayene
    {
        public int MuayeneId { get; set; }
        
        [Required]
        public string Teshis { get; set; }

        [Required]
        public string Durum { get; set; }

        [Required]
        public string Sonuc { get; set; }

        [Required]
        public string Test { get; set; }
        
        [Required]
        public string KullanimSekli { get; set; }
        
        [Required]
        public string BaslangicTarihi  { get; set; }
        
        [Required]
        public string BitisTarihi  { get; set; }

        public string OdemeDurumu  { get; set; }

        public string IslemDurumu  { get; set; }


        public Hasta Hasta { get; set; }

        public BekleyenIslem BekleyenIslem { get; set; }
        
        public GecmisMuayene GecmisMuayene { get; set; }

        public int EtkenMaddeId { get; set; }
        public EtkenMadde EtkenMadde{ get; set; }
    }
}
