using HastaTakipOtomasyonu_DataAccess.Data;
using HastaTakipOtomasyonu_Model.Models;
using HastaTakipOtomasyonu_Model.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HastaTakipOtomasyonu.Controllers
{
    [Authorize]
    public class DoctorListController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DoctorListController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(Doktor obj)
        {
            List<Doktor> objList = _db.Doktorlar.Include(a=>a.Klinik).ToList();
            return View(objList);
        }

        [HttpGet]
        public IActionResult Update_Insert(int? id)
        {
            DoktorVM obj = new DoktorVM();
            obj.KlinikListesi = _db.Klinikler
                .OrderBy(a => a.KlinikAdi)
                .Select(a => 
                new SelectListItem {
                Text = a.KlinikAdi,
                Value = a.KlinikId.ToString()
            });
            
            if (id == null) 
            {
                return View(obj);
            }

            obj.Doktor = _db.Doktorlar.FirstOrDefault(a => a.DoktorId == id);

            if(obj == null) 
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(DoktorVM obj)
        {
            if(obj.Doktor.DoktorId == 0) 
            {
                _db.Doktorlar.Add(obj.Doktor);
            }

            else 
            {
                _db.Doktorlar.Update(obj.Doktor);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "DoctorList");
        }

        public IActionResult Sil(int id)
        {
            var objDb = _db.Doktorlar.FirstOrDefault(a => a.DoktorId == id);
            _db.Doktorlar.Remove(objDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
