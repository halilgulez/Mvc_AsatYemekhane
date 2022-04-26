using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_AsatYemekhane.Models.Entity;

namespace Mvc_AsatYemekhane.Controllers
{
    public class MarkalarController : Controller
    {
        Asat_YemekhaneEntities db=new Asat_YemekhaneEntities();    
        public ActionResult Index()
        {
            var model = db.Markalar.ToList();   
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new Markalar();
            List<SelectListItem> liste = new List<SelectListItem>(from x in db.Kategoriler
                                                                  
                                                                  select new SelectListItem
                                                                  {
                                                                    Value = x.ID.ToString(),
                                                                    Text  = x.Kategori
                                                                  }
                                                                 ).ToList();
           // ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori",model.KategoriID);
           ViewBag.l = liste;   
            return View();  
        }
        [HttpPost]  
        public ActionResult Ekle(Markalar m)
        {
            return RedirectToAction("Index");
        }
    }
}