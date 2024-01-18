using HastaTakipOtomasyonu_Model.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_Model.Models
{
    public class Hasta
    {
        public int HastaId { get; set; }
        
        [Required]
        public string HastaTc { get; set; }

        [Required]
        public string HastaAdı { get; set; }

        [Required]
        public string HastaSoyadı { get; set; }

        [Required]
        public string HastaDogumTarihi { get; set; }
        
        [Required]
        public string HastaGirisTarihi { get; set; }
        
        [Required]
        public string HastaDogumYeri { get; set; }
        
        [Required]
        public string HastaCinsiyet { get; set; }

        [Required]
        public string KanGrubu { get; set; }
        
        public string Alerji { get; set; }

        [Required]
        public string HastaAdres { get; set; }

        [Required]
        public string HastaTelefon { get; set; }
        
        public string Sikayet { get; set; }

        [NotMapped]
        public string HastaAdSoyad
        {
            get
            {
                return $"{HastaAdı} {HastaSoyadı}";
            }
        }

        public int KlinikId { get; set; }
        public Klinik Klinik { get; set; }

        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
        
        public int? MuayeneId { get; set; }
        public Muayene Muayene { get; set; }
    }
}
