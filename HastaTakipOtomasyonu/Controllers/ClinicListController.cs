using HastaTakipOtomasyonu_DataAccess.Data;
using HastaTakipOtomasyonu_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HastaTakipOtomasyonu.Controllers
{
	[Authorize]
	public class ClinicListController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClinicListController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Klinik> objList = _db.Klinikler.ToList();
            return View(objList);
        }
        
        [HttpGet]
        public IActionResult Update_Insert(int? id)
        {
            Klinik obj = new Klinik();
            if(id == null)
            {
                return View(obj);
            }

            obj = _db.Klinikler.FirstOrDefault(a => a.KlinikId == id);
            
            if(obj == null)
            {
                return NotFound();
            }
            
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(Klinik obj) 
        {
            if(ModelState.IsValid)
            {
                if (obj.KlinikId == 0)
                {
                    _db.Klinikler.Add(obj);
                }
                else
                {
                    _db.Klinikler.Update(obj);
                }
                
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);            
        }
        
        public IActionResult Sil(int id)
        {
            var objDb = _db.Klinikler.FirstOrDefault(a => a.KlinikId == id);
            _db.Klinikler.Remove(objDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
