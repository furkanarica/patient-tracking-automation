using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu_Model.Models.ViewModels
{
    public class HastaVM
    {
        public Hasta Hasta { get; set; }
        public IEnumerable<SelectListItem> KlinikListesi { get; set; }
        public IEnumerable<SelectListItem> DoktorListesi { get; set; }
        public IEnumerable<SelectListItem> EtkenListesi { get; set; }
    }
}
