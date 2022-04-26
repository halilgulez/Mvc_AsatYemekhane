using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_AsatYemekhane.Models.Entity;

namespace Mvc_AsatYemekhane.Controllers
{

    public class KategorilerController : Controller
    {
        Asat_YemekhaneEntities db = new Asat_YemekhaneEntities();
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Ekle2(Kategoriler p)
        {
            db.Kategoriler.Add(p);
            db.SaveChanges();   
            return RedirectToAction("Index");
        }
        public ActionResult GuncelleBilgiGetir(Kategoriler p)
        {
            var model= db.Kategoriler.Find(p.ID);
            if(model==null) return HttpNotFound();
            return View("GuncelleBilgiGetir",model);
        }
        public ActionResult Guncelle(Kategoriler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");       
        }
        public ActionResult SilBilgiGetir(Kategoriler p)
        {
            var model = db.Kategoriler.Find(p.ID);
            if(model == null) return HttpNotFound();
            return View(model);
        }
        public ActionResult Sil(Kategoriler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}