using HastaTakipOtomasyonu_DataAccess.Data;
using HastaTakipOtomasyonu_Model.Models;
using HastaTakipOtomasyonu_Model.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace HastaTakipOtomasyonu.Controllers
{
    [Authorize]
    public class TreatmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TreatmentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var kullaniciAdi = HttpContext.User.Identity.Name.ToString();
            Kullanici kullaniciBilgisi = _db.Kullanicilar.FirstOrDefault(a =>a.KullaniciAdi == kullaniciAdi);
            
            List<Hasta> objList = _db.Hastalar
                .Where(a => a.Doktor.DoktorTc == kullaniciBilgisi.TcNo)
                .ToList();
            return View(objList);
        }

        [HttpGet]
        public IActionResult PatientDetail(int id)
        {
            Hasta obj = new Hasta();

            obj = _db.Hastalar.FirstOrDefault(a => a.HastaId == id);

            if(obj == null)
            {
                return NotFound();
            }
            
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PatientDetail(Hasta obj)
        {
            var objDb = _db.Hastalar.FirstOrDefault(a => a.HastaId == obj.HastaId);
            objDb.Sikayet = obj.Sikayet;
            objDb.Alerji = obj.Alerji;
            
            _db.Hastalar.Update(objDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult PatientExamination(int id)
        {
            HastaVM obj = new HastaVM();

            obj.EtkenListesi = _db.EtkenMaddeler
                .OrderBy(a => a.EtkenAdi)
                .Select(a =>
                new SelectListItem
                {
                    Text = a.EtkenAdi,
                    Value = a.EtkenMaddeId.ToString()
                });

            obj.Hasta = _db.Hastalar.FirstOrDefault(a => a.HastaId == id);

            if (obj.Hasta.MuayeneId != 0)
            {
                obj.Hasta.Muayene = _db.Muayeneler.FirstOrDefault(a => a.MuayeneId == obj.Hasta.MuayeneId);
            }

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PatientExamination(HastaVM obj)
        {
            if (obj.Hasta.Muayene.MuayeneId == 0)
            {
                _db.Muayeneler.Add(obj.Hasta.Muayene);
                _db.SaveChanges();

                var HastaDb = _db.Hastalar.FirstOrDefault(a => a.HastaId == obj.Hasta.HastaId);
                HastaDb.MuayeneId = obj.Hasta.Muayene.MuayeneId;
                _db.SaveChanges();
            }
            else
            {
                _db.Muayeneler.Update(obj.Hasta.Muayene);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemovePatientInfo(int id)
        {
            var obj = _db.Hastalar.FirstOrDefault(a => a.HastaId == id);

            if (obj.MuayeneId != null && obj.MuayeneId !=0)
            {
                BekleyenIslem objIslem = JsonConvert.DeserializeObject<BekleyenIslem>(JsonConvert.SerializeObject(obj));

                _db.BekleyenIslemler.Add(objIslem);
                _db.Hastalar.Remove(obj);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult PastTreatments()
        {
            var kullaniciAdi = HttpContext.User.Identity.Name.ToString();
            Kullanici kullaniciBilgisi = _db.Kullanicilar.FirstOrDefault(a => a.KullaniciAdi == kullaniciAdi);

            List<GecmisMuayene> objList = _db.GecmisMuayeneler
                .Include(a => a.Muayene)
                .Where(a => a.Doktor.DoktorTc == kullaniciBilgisi.TcNo)
                .ToList();
            return View(objList);
        }

        [HttpGet]
        public IActionResult PastPatientDetail(int id)
        {
            GecmisMuayene obj = new GecmisMuayene();

            obj = _db.GecmisMuayeneler.FirstOrDefault(a => a.GecmisMuayeneId == id);
            
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult PastTreatmentDetail(int id)
        {
            GecmisMuayene obj = new GecmisMuayene();

            obj = _db.GecmisMuayeneler
                .Include(a => a.Muayene)
                .FirstOrDefault(a => a.GecmisMuayeneId == id);

            if(obj == null) 
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult PastMedicineReport(int id)
        {
            GecmisMuayene obj = new GecmisMuayene();

            obj = _db.GecmisMuayeneler
                .Include(a => a.Muayene.EtkenMadde)
                .FirstOrDefault(a => a.GecmisMuayeneId == id);
            
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
