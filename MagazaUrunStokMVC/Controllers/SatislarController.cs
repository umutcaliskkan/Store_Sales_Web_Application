using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunStokMVC.Models.Entity;

namespace MagazaUrunStokMVC.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        DbMvcMagazaStokEntities db = new DbMvcMagazaStokEntities();
        public ActionResult Index()
        {
            var satislar = db.tblsatislar.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            //URUNLER
            List<SelectListItem> urun = (from x in db.tblurunler.ToList()   /*Yeni satış sayfasında dropdown a getirlen ürün adlarının id si çekiliyor*/
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop1 = urun;
            
            //PERSONEL
            List<SelectListItem> per = (from x in db.tblpersonel.ToList()   /*Yeni satış sayfasında dropdown a getirlen personel adlarının id si çekiliyor*/
                                         select new SelectListItem
                                         {
                                             Text = x.ad +" "+ x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.drop2 = per;
            
            //MÜŞTERİLER
            List<SelectListItem> must = (from x in db.tblmusteri.ToList()   /*Yeni satış sayfasında dropdown a getirlen müşteri adlarının id si çekiliyor*/
                                         select new SelectListItem
                                         {
                                             Text = x.ad + " " + x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.drop3 = must;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(tblsatislar p)
        {

            var urun = db.tblurunler.Where(x => x.id == p.tblurunler.id).FirstOrDefault();   /*Kategori id si çekiliyor */
            var musteri = db.tblmusteri.Where(x => x.id == p.tblmusteri.id).FirstOrDefault();
            var personel = db.tblpersonel.Where(x => x.id == p.tblpersonel.id).FirstOrDefault();
            p.tblurunler = urun;
            p.tblmusteri = musteri;
            p.tblpersonel = personel;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tblsatislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}