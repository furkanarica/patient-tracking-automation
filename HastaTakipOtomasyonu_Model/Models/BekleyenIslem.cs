using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_Model.Models
{
    public class BekleyenIslem
    {
        public int BekleyenIslemId { get; set; }

        public string HastaTc { get; set; }

        public string HastaAdı { get; set; }

        public string HastaSoyadı { get; set; }

        public string HastaDogumTarihi { get; set; }

        public string HastaGirisTarihi { get; set; }
        
        public string HastaDogumYeri { get; set; }

        public string HastaCinsiyet { get; set; }

        public string KanGrubu { get; set; }

        public string Alerji { get; set; }

        public string HastaAdres { get; set; }

        public string HastaTelefon { get; set; }

        public string Sikayet { get; set; }

        public bool IslemKontrol { get; set; }

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

        public int MuayeneId { get; set; }
        public Muayene Muayene { get; set; }
    }
}
