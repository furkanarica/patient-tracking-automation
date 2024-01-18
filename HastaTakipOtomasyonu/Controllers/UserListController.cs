using HastaTakipOtomasyonu_DataAccess.Data;
using HastaTakipOtomasyonu_Model.Models;
using HastaTakipOtomasyonu_Model.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System;

namespace HastaTakipOtomasyonu.Controllers
{
    [Authorize]
    public class UserListController : Controller
	{
        private readonly ApplicationDbContext _db;

		public UserListController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
            List<Kullanici> objList = _db.Kullanicilar.Include(a => a.Yetki).ToList();
			return View(objList);
		}

        [HttpGet]
		public IActionResult Update_Insert(int? id) 
		{
			KullaniciVM obj = new KullaniciVM();
            obj.YetkiListesi = _db.Yetkiler.Select(a => new SelectListItem
            {
                Text = a.YetkiAdi,
                Value = a.YetkiId.ToString()
            });

            if (id ==null)
			{
				return View(obj);
			}

			obj.Kullanici = _db.Kullanicilar.FirstOrDefault(a => a.KullaniciId == id);

			if(obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(KullaniciVM obj)
		{
                if (obj.Kullanici.KullaniciId == 0)
                {
                    _db.Kullanicilar.Add(obj.Kullanici);
                }

                else
                {
                    _db.Kullanicilar.Update(obj.Kullanici);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));           
        }

        public IActionResult Sil(int id)
        {
            var objDb = _db.Kullanicilar.FirstOrDefault(a => a.KullaniciId == id);
            _db.Kullanicilar.Remove(objDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
