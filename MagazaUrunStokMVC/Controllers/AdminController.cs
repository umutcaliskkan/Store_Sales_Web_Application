using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunStokMVC.Models.Entity;

namespace MagazaUrunStokMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DbMvcMagazaStokEntities db = new DbMvcMagazaStokEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniAdmin(tbladmin p)
        {
            db.tbladmin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}