using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_Model.Models
{
    public class Yetki
    {
        public int YetkiId { get; set; }
        public string YetkiAdi { get; set; }
        public List<Kullanici> Kullanici { get; set; }

    }
}
