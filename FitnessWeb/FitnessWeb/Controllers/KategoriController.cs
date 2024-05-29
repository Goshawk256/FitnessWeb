using FitnessWeb.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FitnessWeb.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var kategori = c.Kategoris.Where(x=> x.durum == true).ToList();
            return View(kategori);
        }
        [HttpGet]
        public ActionResult Ekle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Kategori k)
        {
            k.durum = true;
            c.Kategoris.Add(k);
            c.SaveChanges();
            Thread.Sleep(2000);

            return RedirectToAction("Index", "Kategori");
        }
        public ActionResult Sil(int Id)
        {
            var kategori = c.Kategoris.Find(Id);
            kategori.durum = false;
            c.SaveChanges();
            Thread.Sleep(2000);

            return RedirectToAction("Index", "Kategori");
        }

        [HttpGet]
        public ActionResult Guncelle(int Id)
        {
            
            var kategori = c.Kategoris.Find(Id);
            return View("Guncelle", kategori);
        }

        public ActionResult Update(Kategori k)
        {
            var kategori = c.Kategoris.Find(k.KategoriId);
            kategori.KategoriAd = k.KategoriAd;
            c.SaveChanges();
          return RedirectToAction("Index"); 

        }
    }
}