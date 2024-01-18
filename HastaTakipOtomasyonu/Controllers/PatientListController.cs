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
    public class PatientListController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PatientListController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Hasta> objList = _db.Hastalar
                .Include(a=>a.Doktor)
                .Include(a=>a.Klinik)
                .ToList();
            
            return View(objList);            
        }

        [HttpGet]
        public IActionResult Update_Insert(int? id)
        {
            HastaVM obj = new HastaVM();

            obj.KlinikListesi = _db.Klinikler
                .OrderBy(a => a.KlinikAdi)
                .Select(a =>
                new SelectListItem
                {
                    Text = a.KlinikAdi,
                    Value = a.KlinikId.ToString()
                });

            obj.DoktorListesi = _db.Doktorlar
                .OrderBy(a => a.DoktorAd)
                .Select(a =>
                new SelectListItem
                {
                    Text = a.DoktorAdSoyad,
                    Value = a.DoktorId.ToString()
                });
            
            if (id == null)
            {
                return View(obj);
            }

            obj.Hasta = _db.Hastalar.FirstOrDefault(a => a.HastaId == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(HastaVM obj)
        {
            if (obj.Hasta.HastaId == 0)
            {
                _db.Hastalar.Add(obj.Hasta);
            }

            else
            {
                _db.Hastalar.Update(obj.Hasta);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Sil(int id)
        {
            var objDb = _db.Hastalar.FirstOrDefault(a => a.HastaId == id);
            _db.Hastalar.Remove(objDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PendingTransactions()
        {
            List<BekleyenIslem> objList = _db.BekleyenIslemler
                .Include(a => a.Muayene)
                .Include(a => a.Doktor)
                .Include(a => a.Klinik)
                .ToList();

            return View(objList);                
        }

        [HttpGet]
        public IActionResult TransactionDetail(int id)
        {
            BekleyenIslem obj = new BekleyenIslem();

            obj = _db.BekleyenIslemler
                .Include(a => a.Doktor)
                .Include (a => a.Klinik)
                .Include(a => a.Muayene)
                .FirstOrDefault(a => a.BekleyenIslemId == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TransactionDetail(BekleyenIslem obj)
        {   
            var objBekleyenDb = _db.BekleyenIslemler.FirstOrDefault(a => a.BekleyenIslemId == obj.BekleyenIslemId);
            
            var objMuayeneDb = _db.Muayeneler.FirstOrDefault(a => a.MuayeneId == obj.Muayene.MuayeneId);
            
            objMuayeneDb.OdemeDurumu = obj.Muayene.OdemeDurumu;
            objMuayeneDb.IslemDurumu = obj.Muayene.IslemDurumu;
            
            objBekleyenDb.IslemKontrol = true;
            
            _db.BekleyenIslemler.Update(objBekleyenDb);
            _db.Muayeneler.Update(objMuayeneDb);
            _db.SaveChanges();
            return RedirectToAction("PendingTransactions");
        }

        public IActionResult CompleteTransaction(int id)
        {
            var obj = _db.BekleyenIslemler.FirstOrDefault(a => a.BekleyenIslemId == id);

            if (obj.IslemKontrol == true)
            {
                GecmisMuayene objGecmis = JsonConvert.DeserializeObject<GecmisMuayene>(JsonConvert.SerializeObject(obj));

                _db.GecmisMuayeneler.Add(objGecmis);
                _db.BekleyenIslemler.Remove(obj);
                _db.SaveChanges();
         }
            return RedirectToAction("PendingTransactions");
        }
    }
}
