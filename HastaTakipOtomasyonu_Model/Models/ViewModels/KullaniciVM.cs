using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_Model.Models.ViewModels
{
    public class KullaniciVM
    {
        public Kullanici Kullanici { get; set; }
        public IEnumerable<SelectListItem> YetkiListesi { get; set; }
    }
}
