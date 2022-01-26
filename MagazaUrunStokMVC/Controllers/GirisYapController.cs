using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunStokMVC.Models.Entity;
using System.Web.Security; //Giriş işlemi için kütüphane eklendi

namespace MagazaUrunStokMVC.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        DbMvcMagazaStokEntities db = new DbMvcMagazaStokEntities();
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(tbladmin t)
        {
            var bilgiler = db.tbladmin.FirstOrDefault(x => x.kullanici == t.kullanici && x.sifre == t.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "Musteri");

            }
            else
            {
                return View();
            }
           
        }
    }
}