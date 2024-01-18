using HastaTakipOtomasyonu_DataAccess.Data;
using HastaTakipOtomasyonu_Model.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HastaTakipOtomasyonu.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Kullanici obj)
        {
            var kullaniciBilgisi = _db.Kullanicilar.Include(a => a.Yetki).FirstOrDefault(a => a.KullaniciAdi == obj.KullaniciAdi && a.Sifre == obj.Sifre);
            if (kullaniciBilgisi != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,obj.KullaniciAdi)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                
                if (kullaniciBilgisi.Yetki.YetkiAdi == "Yönetici")
                {
                     return RedirectToAction("Index", "UserList");
                }
                
                else if (kullaniciBilgisi.Yetki.YetkiAdi == "Personel")
                {
                    return RedirectToAction("Index", "PatientList");
                }
                
                else if(kullaniciBilgisi.Yetki.YetkiAdi == "Doktor")
                {
                    return RedirectToAction("Index", "Treatment");
                }
            }

            return RedirectToAction("Index", "Login");
        }
        
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }                
    }
}
