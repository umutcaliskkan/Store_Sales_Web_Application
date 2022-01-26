using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunStokMVC.Models.Entity;

namespace MagazaUrunStokMVC.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcMagazaStokEntities db = new DbMvcMagazaStokEntities();
        public ActionResult Index()
        {
            var kategoriler = db.tblkategori.ToList();
            return View(kategoriler);
        }

         //Sayfa Yüklendiğinde View döndürülsün
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(tblkategori p)  /*tbl kategoriden p isimli parametre üretildi*/
        {
            db.tblkategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index"); /*beni index aksiyonuna yönlendir*/
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = db.tblkategori.Find(id);
            db.tblkategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tblkategori.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult KategoriGuncelle(tblkategori k)
        {
            var ktg = db.tblkategori.Find(k.id);
            ktg.ad = k.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}