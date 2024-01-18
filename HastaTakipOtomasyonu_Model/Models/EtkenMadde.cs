using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_Model.Models
{
    public class EtkenMadde
    {
        public int EtkenMaddeId { get; set; }
        
        [Required]
        public string EtkenKodu { get; set; }
        
        [Required]
        public string EtkenAdi { get; set; }
        
        public List<Muayene> Muayene { get; set; }
    }
}
