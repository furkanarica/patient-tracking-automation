using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HastaTakipOtomasyonu_Model.Models
{
    public class Klinik
    {
        public int KlinikId { get; set; }
        
        [Required]
        public string KlinikAdi { get; set; }
        
        [Required]
        public string KlinikKodu { get; set; }

        public List<Doktor> Doktor { get; set; }
        
        public List<Hasta> Hasta { get; set; }

        public List<BekleyenIslem> BekleyenIslem { get; set; }
        
        public List<GecmisMuayene> GecmisMuayene { get; set; }
    }
}
