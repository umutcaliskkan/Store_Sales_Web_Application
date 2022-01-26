using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunStokMVC.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MagazaUrunStokMVC.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcMagazaStokEntities db = new DbMvcMagazaStokEntities();
        [Authorize] //Giriş yapılmadan müşteri index sayfasının açılması engelleniyor
        public ActionResult Index(int sayfa=1)
        {
            // var musteriliste = db.tblmusteri.ToList();
            var musteriliste = db.tblmusteri.Where(x=>x.durum==true).ToList().ToPagedList(sayfa, 3);
            return View(musteriliste);
        }
        
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(tblmusteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            p.durum = true;
            db.tblmusteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(tblmusteri p)
        {
            var musteribul = db.tblmusteri.Find(p.id);
            musteribul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {

            var mus = db.tblmusteri.Find(id);
            
            return View("MusteriGetir", mus);
        }

        public ActionResult MusteriGuncelle(tblmusteri t)
        {
            var mus = db.tblmusteri.Find(t.id);
            mus.ad = t.ad;
            mus.soyad = t.soyad;
            mus.sehir = t.sehir;
            mus.bakiye = t.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}